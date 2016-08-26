<%@ Page Title="Номенклатура" Language="C#" MasterPageFile="~/WebForms/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ZipData.aspx.cs" Inherits="ZipClaim.WebForms.Claims.ZipData" %>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <div id="zipDataContainer">
        
    </div>
    <script>

        $(function() {
            loadZipDataList();
        });

        function loadZipDataList() {
            var $cont = $('#zipDataContainer');
            var queryString = window.location.href.split("?")[1];
            showSpinner($cont);
            $.ajax({
                url: '<%# ConfigurationManager.AppSettings["ZipClaimUrl"] %>/Zip/Index?' + queryString,
                success: function(data) {
                    $cont.html(data);
                    $('#removeFilter').click(function() {
                        var url = '<%# ConfigurationManager.AppSettings["ZipClaimUrl"] %>/Claims/ZipData';
                        window.location = url;
                    });
                    $('.erp-handled-js').click(setErpHandled);
                    $('#claimNumSearch').keydown(inputSearch);
                    $('#catNumSearch').keydown(inputSearch);
                    $('#systemHandledCountAlert').hide();
                    hideSpinner($cont);
                },
                error: function(data) {
                    console.error(data);
                    hideSpinner($cont);
                }
            });
        }

        function inputSearch(e) {
            if (e.keyCode != 13) return;
            search();
        }

        function search() {
            var queryString = window.location.href.split("?")[1];
            var url = '<%# ConfigurationManager.AppSettings["ZipClaimUrl"] %>/Claims/ZipData?' + queryString;

            var claimnum = $('#claimNumSearch').val();
            if (claimnum == 'null' || claimnum == null) claimnum = '';
            url = replaceQueryString(url, 'claimnum', claimnum);

            var catnum = $('#catNumSearch').val();
            if (catnum == 'null' || catnum == null) catnum = '';
            url = replaceQueryString(url, 'catnum', catnum);
            
            window.location = url;
        }

        function setErpHandled() {
            var id = $(this).attr('zuid');

            $.ajax({
                url: '<%# ConfigurationManager.AppSettings["ZipClaimUrl"] %>/Zip/SetErpHandled',
                method: 'POST',
                data: { id },
                success: function (data) {
                    reloadZipDataItem(id);
                    for (var i = 0; i < data.length; i++) {
                        var item = data[i];
                        reloadZipDataItem(item);
                    }
                    $('#systemHandledCount').text(data.length);
                    $('#systemHandledCountAlert').hide();
                    $('#systemHandledCountAlert').show();
                    setTimeout(function() {
                        $('#systemHandledCountAlert').hide();
                    }, 3000);
                },error:function(data) {
                    console.error(data);
                }
            });
            return false;
        }

        function reloadZipDataItem(id){
            $.ajax({
                url: '<%# ConfigurationManager.AppSettings["ZipClaimUrl"] %>/Zip/ZipDataItem',
                method: 'POST',
                data: { id },
                success:function(data) {
                    $('.zip-data-item[zid=' + id + ']').replaceWith(data);
                },error:function(data) {
                    console.error(data);
                }
            });
        }
    </script>
</asp:Content>
