<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeListForm.aspx.cs" Inherits="_02_WebForms_Uygulama.EmployeeListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Çalışan Listesi</h2>

    <div class="row">
        <div class="col-md-12">
            <div class="pull-right">
                <a href="EmployeeEditForm.aspx" class="btn btn-default">Yeni Çalışan</a>
            </div>
        </div>
    </div>
    <br />

    <table id="tblEmployeeList" class="table table-bordered">
        <tr>
            <td>
                <b>#</b>
            </td>
            <td>
                <b>EmployeeID</b>
            </td>
            <td>
                <b>TitleOfCourtesy</b>
            </td>
            <td>
                <b>LastName</b>
            </td>
            <td>
                <b>FirstName</b>
            </td>
            <td>
                <b>Title</b>
            </td>
        </tr>
        <asp:Repeater ID="RepeatEmployeeList" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Sil" data-id='<%# Eval("EmployeeID") %>' CssClass="btn btn-xs btn-danger" OnClick="btnDelete_Click" />

                        <a class="btn btn-xs btn-warning" href="EmployeeEditForm.aspx?id=<%#Eval("EmployeeID") %>">Düzenle</a>
                    </td>
                    <td>
                        <%# Eval("EmployeeID") %>
                    </td>
                    <td>
                        <%# Eval("TitleOfCourtesy") %>
                    </td>
                    <td>
                        <%# Eval("LastName") %>
                    </td>
                    <td>
                        <%# Eval("FirstName") %>
                    </td>
                    <td>
                        <%# Eval("Title") %>
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
