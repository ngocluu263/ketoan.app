<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.master" AutoEventWireup="true" CodeFile="delete_user.aspx.cs" Inherits="pages_delete_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" Runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Tài khoản</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Xóa tài khoản
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <form>
                                <div class="form-group">
                                    <label><asp:Literal ID="lbTen" runat="server" Text=""></asp:Literal></label>
                                </div>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <label>
                                            <input id="chkChacchan" runat="server" type="checkbox" value="">Chắc chắn xóa?
                                        </label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label><asp:Literal ID="lbMessage" runat="server" Text=""></asp:Literal></label>
                                </div>
                                <asp:Button ID="btnRemove" runat="server" Text="Xóa" CssClass="btn btn-default"  ValidationGroup="g1" onclick="btnRemove_Click" />
                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" Text="Trở lại" PostBackUrl="~/pages/users.aspx" />                                
                            </form>
                        </div>
                        <!-- /.col-lg-6 (nested) -->

                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">

</asp:Content>
