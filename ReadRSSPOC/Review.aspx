<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="ReadRSSPOC.Review" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <asp:GridView ID="grdFeed"  runat="server" AutoGenerateColumns="False" AllowPaging="True" 
            PageSize="5" OnPageIndexChanging="grdFeed_PageIndexChanging" CssClass="Gridview">
           <AlternatingRowStyle BackColor="#BFE4FF" ForeColor="Black"  />
            <HeaderStyle BackColor="#7779AF" Font-Bold="True" ForeColor="Black" />
            <RowStyle ForeColor="Black" BackColor="White" Font-Size="15px" Font-Names="Segoe UI" />

            <Columns>
                <asp:BoundField HeaderText = "Title" DataField="title" />
            </Columns>
            <Columns>
                <asp:HyperLinkField  HeaderText = "URL Link" DataNavigateUrlFields="link" DataTextField="link" />
            </Columns>
              <Columns>
                <asp:BoundField HeaderText = "Description" DataField="description" />
            </Columns>
            <Columns>
                <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                <img src='<%# Eval("Image") %>' Height="150" Width="150" />
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
</asp:Content>
