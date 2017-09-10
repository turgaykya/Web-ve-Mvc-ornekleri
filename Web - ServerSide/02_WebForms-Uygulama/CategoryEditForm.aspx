<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoryEditForm.aspx.cs" Inherits="_02_WebForms_Uygulama.CategoryEditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-8 col-md-off2">
            <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" placeholder="Please Enter Category..."></asp:TextBox><br />
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Style="resize: none; min-height: 200px;" placeholder="Please Enter Description..."></asp:TextBox>
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Category Ekle" CssClass="form-control btn-success" OnClick="btnSave_Click" />
        </div>
    </div>

</asp:Content>
