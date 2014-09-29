<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecordList.aspx.cs" Inherits="RecordList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <asp:GridView ID="gvRecord" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="Gray" 
        BorderColor="#E3E5DC" BorderStyle="Ridge" 
        BorderWidth="2px" CellPadding="3" CellSpacing="1" 
        DataKeyNames="OrderId"  GridLines="None" 
        OnPageIndexChanging="gvRecord_PageIndexChanging" PageSize="7" 
        OnRowDeleting="gvRecord_RowDeleting" Width="566px" >
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="訂單編號" InsertVisible="False" ReadOnly="True" SortExpression="OrderId" HeaderStyle-HorizontalAlign="Left">
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Date" DataFormatString="{0:d}" HeaderText="訂購日期" SortExpression="OrderDate" HeaderStyle-HorizontalAlign="Left">
            <ItemStyle Width="110px" />
            </asp:BoundField>
<%--            <asp:TemplateField HeaderText="帳單地址" SortExpression="ShipAddr1">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("billingAddress.address1") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="130px" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="寄送地址" SortExpression="BillAddr1" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("shippingAddress.address1") %>' Width="200px"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="110px" />
            </asp:TemplateField>
            <asp:BoundField DataField="orderTotal" HeaderText="總金額" SortExpression="total" ItemStyle-Wrap="True" HeaderStyle-HorizontalAlign="Left">
                <ItemStyle Width="80px" /></asp:BoundField>

            <asp:TemplateField >
                <ItemTemplate>
                    <ItemStyle Width="110px" />
                    <asp:HyperLink ID="LinkButton1" runat="server"  Text="更新訂單"
                        NavigateUrl='<%# string.Format("~/UpdateOrder.aspx?OrderId={0}", Eval("OrderId")) %>'>
                        <input id="Button1" type="button" value="更新訂單" />
                    </asp:HyperLink>
                     <asp:LinkButton ID="DelButton" runat="server" CausesValidation="False" CommandName="Delete" Text="取消訂單"
                       OnClientClick="if (confirm('確定要取消訂單?') == false) return false;" >
                        <input id="Button1" type="button" value="取消訂單" />
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle  CssClass="pageHeader" HorizontalAlign="Center" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3E5DC" ForeColor="Black" HorizontalAlign ="Center" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />

    </asp:GridView>
<%--    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString3 %>" SelectCommand="SELECT * FROM [Orders]"></asp:SqlDataSource>--%>
</asp:Content>

