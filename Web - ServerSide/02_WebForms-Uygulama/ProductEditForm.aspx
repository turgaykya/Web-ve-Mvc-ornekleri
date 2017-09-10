<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductEditForm.aspx.cs" Inherits="_02_WebForms_Uygulama.ProductEditForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-8 col-md-off2">
            <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Please Enter ProductName..."></asp:TextBox><br />

            <asp:DropDownList ID="dropDownCategory" runat="server" CssClass="form-control"></asp:DropDownList>
            <br />
            <asp:TextBox ID="txtUnitsInStock" runat="server" CssClass="form-control" placeholder="Please Enter UnitsInStock..."></asp:TextBox>
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Ürün Ekle" CssClass="form-control btn-success" OnClick="btnSave_Click" />
        </div>
    </div>


</asp:Content>
