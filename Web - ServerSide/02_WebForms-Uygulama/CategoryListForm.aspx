<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoryListForm.aspx.cs" Inherits="_02_WebForms_Uygulama.CategoryListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Kategori Listesi</h2>


    <div class="row">
        <div class="col-md-12">
            <div class="pull-right">
                <a href="CategoryEditForm.aspx" class="btn btn-default">Yeni Kategori</a>
            </div>
        </div>
    </div>
    <br />
    <asp:GridView ID="gridCategories" runat="server" CssClass="table table-bordered">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>

                    <asp:Button ID="btnDelete" runat="server" Text="Sil" data-id='<%# Eval("CategoryID") %>' OnClick="btnDelete_Click" CssClass="btn btn-xs btn-danger" />

                    <a class="btn btn-xs btn-warning" href="CategoryEditForm.aspx?id=<%# Eval("CategoryID") %>">Düzenle</a>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
