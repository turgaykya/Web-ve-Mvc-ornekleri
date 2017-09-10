<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductListForm.aspx.cs" Inherits="_02_WebForms_Uygulama.ProductListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Ürün Listesi</h2>

    <div class="row">
        <div class="col-md-12">
            <div class="pull-right">
                <a href="ProductEditForm.aspx" class="btn btn-default">Yeni Ürün</a>
            </div>
        </div>
    </div>
    <br />
    <asp:GridView ID="gridProducts" runat="server" CssClass="table table-bordered">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>

                    <asp:Button ID="btnDelete" runat="server" Text="Sil" data-id='<%# Eval("ProductID") %>' OnClick="btnDelete_Click" CssClass="btn btn-xs btn-danger" />

                    <a class="btn btn-xs btn-warning" href="ProductEditForm.aspx?id=<%#Eval("ProductID") %>">Düzenle</a>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>


    </asp:GridView>



</asp:Content>
