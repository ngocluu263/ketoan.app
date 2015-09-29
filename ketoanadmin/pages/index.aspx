<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="pages_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" Runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Bảng điều khiển</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-tasks fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge"><asp:Literal ID="lbCountCustomer" runat="server" Text="0"></asp:Literal></div>
                            <div>Khách hàng</div>
                        </div>
                    </div>
                </div>
                <a href="customers.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">Chi tiết</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-support fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge"><asp:Literal ID="lbCountCustomerSetups" runat="server" Text="0"></asp:Literal></div>
                            <div>Cài đặt</div>
                        </div>
                    </div>
                </div>
                <a href="customerSetups.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">Chi tiết</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-tasks fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge"><asp:Literal ID="lbCountUser" runat="server" Text="0"></asp:Literal></div>
                            <div>Tài khoản</div>
                        </div>
                    </div>
                </div>
                <a href="users.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">Chi tiết</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">

</asp:Content>
