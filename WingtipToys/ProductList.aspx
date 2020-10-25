<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="WingtipToys.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <hgroup>
            <%: Page.Title %>
        </hgroup>

        <asp:ListView runat="server" ID="ProductLists" GroupItemCount="4" DataKeyNames="ProductID"
            ItemType="WingtipToys.Models.Product" SelectMethod="GetProducts">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table>
                        <tr>
                            <td>
                                <a href="ProductDetails.aspx?productID=<%#:Item.ProductID%>">
                                    <img src="/Catalog/Images/Thumbs/<%#:Item.ImagePath%>"
                                        width="100" height="75" style="border: solid" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="ProductDetails.aspx?productID=<%#:Item.ProductID%>">
                                    <span>
                                        <%#:Item.ProductName%>
                                    </span>
                                </a>
                                <br />
                                <span>
                                    <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                                </span>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </p>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table style="width: 100%;">
                    <tbody>
                        <tr>
                            <td>
                                <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                    <tr id="groupPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </section>
</asp:Content>
