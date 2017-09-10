<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeEditForm.aspx.cs" Inherits="_02_WebForms_Uygulama.EmployeeEditForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-8 col-md-off2">

            <asp:TextBox ID="txtTitleOfCourtesy" runat="server" CssClass="form-control" placeholder="Please Enter TitleOfCourtesy..."></asp:TextBox><br />

            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Please Enter LastName..."></asp:TextBox><br />

            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Please Enter FirstName..."></asp:TextBox><br />

            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Please Enter Title..."></asp:TextBox><br />

            <asp:Button ID="btnSave" runat="server" Text="Employee Ekle" CssClass="form-control btn-success" OnClick="btnSave_Click" />

        </div>
    </div>

</asp:Content>
