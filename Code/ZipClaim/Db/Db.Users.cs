﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using ZipClaim.Models;

namespace ZipClaim.Db
{
    public partial class Db
    {
        public class Users
        {
            #region Константы

            private const string sp = "ui_users";

            #endregion

            public static User GetUserBySid(string sid)
            {
                User user;

                SqlParameter pSid = new SqlParameter() { ParameterName = "user_sid", Value = sid, DbType = DbType.AnsiString };
                DataTable dt = ExecuteQueryStoredProcedure(sp, "getUserBySid", pSid);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    int id = (int)dr["id_user"];
                    string login = dr["login"].ToString();
                    string userSid = dr["sid"].ToString();
                    string fullName = dr["full_name"].ToString();
                    string displayName = dr["display_name"].ToString();
                    string mail = dr["mail"].ToString();
                    bool enabled = (bool)dr["enabled"];
                    string company = dr["company"].ToString();

                    if (String.IsNullOrEmpty(displayName)) displayName = fullName;

                    user = new User(id, login, fullName, displayName, mail) { Enabled = enabled, AdSid = userSid, Company = company };


                    SqlParameter pUserId = new SqlParameter()
                    {
                        ParameterName = "id_user",
                        Value = user.Id,
                        DbType = DbType.Int32
                    };
                    dt = ExecuteQueryStoredProcedure(sp, "getEtUserByUserId", pUserId);

                    EtalonUser etUser;

                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.Rows[0];

                        int etId = (int)dr["id_et_user"];
                        string etLogin = dr["et_login"].ToString();
                        string etPassword = dr["et_password"].ToString();
                        string etDisplayName = dr["et_display_name"].ToString();
                        string adSid = dr["ad_sid"].ToString();

                        etUser = new EtalonUser(etId, etLogin, etPassword, etDisplayName) { AdSid = adSid };
                    }
                    else
                    {
                        string etDisplayName = "Не зарегистрирован";
                        etUser = new EtalonUser() { DisplayName = etDisplayName };
                    }

                    user.EtUser = etUser;
                }
                else
                {
                    user = new User();
                }

                return user;
            }

            public static DataTable GetUsersSelectionList()
            {
                DataTable dt = new DataTable();

                dt = ExecuteQueryStoredProcedure(sp, "getUsersSelectionList");
                return dt;
            }

            public static DataTable GetUsersSelectionList(string groupName, DataTable dtUsers = null, params string[] groupSidsElse)
            {
                if (dtUsers == null)
                {
                    dtUsers = GetUsersSelectionList();
                }

                //List<string> logins = new List<string>();

                string userGroupSid = string.Empty;
                string programName = WebConfigurationManager.AppSettings["progName"];

                SqlParameter pProgramName = new SqlParameter() { ParameterName = "program_name", Value = programName, DbType = DbType.AnsiString };
                SqlParameter pRightName = new SqlParameter() { ParameterName = "sys_name", Value = groupName, DbType = DbType.AnsiString };

                DataTable dtGroupSid = ExecuteQueryStoredProcedure(sp, "getUserGroupSid", pProgramName, pRightName);
                if (dtGroupSid.Rows.Count > 0)
                {
                    userGroupSid = dtGroupSid.Rows[0]["sid"].ToString();
                }


                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().Name);
                GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Sid, userGroupSid);

                var members = grp.GetMembers(false);

                DataTable dt;
                List<string> sids = new List<string>();

                foreach (Principal member in members)
                {
                    sids.Add("'" + member.Sid.ToString() + "'");
                }

                if (groupSidsElse != null)
                {
                    foreach (string grpSid in groupSidsElse)
                    {
                        userGroupSid = grpSid;

                        ctx = new PrincipalContext(ContextType.Domain, System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().Name);
                        grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Sid, userGroupSid);

                        members = grp.GetMembers(false);
                        
                        foreach (Principal member in members)
                        {
                            sids.Add("'" + member.Sid.ToString() + "'");
                        }
                    }
                }

                //foreach (DataRow dr in dtUsers.Rows)
                //{
                //    string login = dr["login"].ToString();

                //    if (CheckUserRights(login, groupName, userGroupSid))
                //    {
                //        logins.Add(String.Format("'{0}'", login));
                //    }
                //}

                //DataTable dt;

                if (sids.Any())
                {
                    //string expression = String.Format("login in ({0})", String.Join(",", logins));

                    string expression = String.Format("sid in ({0})", String.Join(",", sids));

                    dt = dtUsers.Select(expression, "name asc").CopyToDataTable();
                }
                else
                {
                    dt = dtUsers;
                }

                return dt;
            }

            public static bool CheckUserRights(string userLogin, string rightName, string userGroupSid = null)
            {
                string programName = WebConfigurationManager.AppSettings["progName"];
                bool flag = false;

                SqlParameter pProgramName = new SqlParameter() { ParameterName = "program_name", Value = programName, DbType = DbType.AnsiString };
                SqlParameter pRightName = new SqlParameter() { ParameterName = "sys_name", Value = rightName, DbType = DbType.AnsiString };

                DataTable dt = new DataTable();
                string sid = string.Empty;

                if (String.IsNullOrEmpty(userGroupSid))
                {
                    dt = ExecuteQueryStoredProcedure(sp, "getUserGroupSid", pProgramName, pRightName);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        sid = dr["sid"].ToString();
                    }
                }
                else
                {
                    sid = userGroupSid;
                }
                

                if (!String.IsNullOrEmpty(sid))
                {
                    try
                    {
                        WindowsIdentity wi = new WindowsIdentity(userLogin);
                        WindowsPrincipal wp = new WindowsPrincipal(wi);
                        SecurityIdentifier grpSid = new SecurityIdentifier(sid);
                        

                        flag = wp.IsInRole(grpSid);
                    }
                    catch (Exception ex)
                    {
                        flag = false;
                    }
                }

                return flag;
            }
        }
    }
}