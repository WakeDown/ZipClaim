<%@ Page Title="Номенклатура" Language="C#" MasterPageFile="~/WebForms/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ZipData.aspx.cs" Inherits="ZipClaim.WebForms.Claims.ZipData" %>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <div id="zipDataContainer">
        
    </div>
    <script>
        $(function() {
            var $cont = $('#zipDataContainer');
            var queryString = window.location.href.slice(window.location.href.indexOf('?') + 1);
            $.ajax({
                url: '<%# ConfigurationManager.AppSettings["ZipClaimUrl"] %>/Zip/Index?' + queryString,
                success:function(data) {
                    $cont.html(data);
                },
                error:function(data) {
                   console.error(data);
                }
            });
        })
    </script>
</asp:Content>
