<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.master" AutoEventWireup="true" CodeFile="customer.aspx.cs" Inherits="pages_customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" Runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Khách hàng</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Chi tiết khách hàng
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <form>
                                <div class="form-group">
                                    <label>Tên/Công ty</label>
                                    <input id="txtTen" runat="server" class="form-control">
                                    <asp:RequiredFieldValidator ID="rqf1" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtTen" ErrorMessage="Chưa nhập Tên/Công ty!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Địa chỉ</label>
                                    <input id="txtDiachi" runat="server" class="form-control">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtDiachi" ErrorMessage="Chưa nhập Địa chỉ!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Appcode</label>
                                    <p class="form-control-static"><asp:Literal ID="lbAppcode" runat="server" Text="Appcode sẽ được hệ thống tạo tự động!"></asp:Literal></p>
                                </div>
                                <div class="form-group">
                                    <label>Số lượng</label>
                                    <input id="txtSoluong" runat="server" class="form-control">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtSoluong" ErrorMessage="Chưa nhập Số lượng!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Kích hoạt</label>
                                    <asp:DropDownList ID="ddlKichhoat" runat="server" CssClass="form-control">
                                        <asp:ListItem Value= "1" Selected="True">True</asp:ListItem>
                                        <asp:ListItem Value= "0">False</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-default"  ValidationGroup="g1" onclick="btnSave_Click" />
                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" Text="Trở lại" PostBackUrl="~/pages/customers.aspx" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" ShowSummary="False" ValidationGroup="g1" />
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
