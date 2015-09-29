<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.master" AutoEventWireup="true" CodeFile="customers.aspx.cs" Inherits="pages_customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<!-- DataTables CSS -->
    <link href="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css" rel="stylesheet">
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
                    Danh sách khách hàng
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="dataTable_wrapper">
                        <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>Tên/Công ty</th>
                                    <th>Địa chỉ</th>
                                    <th>Appcode</th>
                                    <th>Số lượng</th>
                                    <th>Kích hoạt</th>
                                    <th>Ngày tạo</th>
                                    <th>#</th>
                                </tr>
                            </thead>
                            <tbody>                                
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td><%# Eval("Fullname")%></td>
                                            <td><%# Eval("Address")%></td>
                                            <td><%# Eval("Appcode")%></td>
                                            <td class="center"><%# Eval("Appnumber")%></td>
                                            <td class="center"><%# Eval("IsActive")%></td>
                                            <td><%# formatDate(Eval("CreatedDate"))%></td>
                                            <td class="center"><a href='<%# getLink(DataBinder.Eval(Container.DataItem, "ID")) %>'>Chỉnh sửa</a> | 
                                            <a href='<%# getLinkDelete(DataBinder.Eval(Container.DataItem, "ID")) %>'>Xóa</a></td>
                                        </tr>    
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <!-- /.table-responsive -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
    <!-- DataTables JavaScript -->
    <script src="../bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
    <script src="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"></script>

    <!-- Page-Level Demo Scripts - Tables - Use for reference -->
    <script>
        $(document).ready(function () {
            $('#dataTables-example').DataTable({
                responsive: true
            });
        });
    </script>
</asp:Content>
