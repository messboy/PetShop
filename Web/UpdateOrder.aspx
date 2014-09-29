<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateOrder.aspx.cs" Inherits="UpdateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" Height="1050px" Width="608px" AutoGenerateRows="False" DataKeyNames="OrderId" DefaultMode="Edit" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" DataSourceID="SqlDataSource2">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <Fields>
            <asp:BoundField DataField="OrderId" HeaderText="OrderId" InsertVisible="False" ReadOnly="True" SortExpression="OrderId" />
            <asp:BoundField DataField="UserId" HeaderText="UserId"  SortExpression="UserId" />
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
            <asp:BoundField DataField="ShipAddr1" HeaderText="ShipAddr1" SortExpression="ShipAddr1" />
            <asp:BoundField DataField="ShipAddr2" HeaderText="ShipAddr2" SortExpression="ShipAddr2" />
            <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity" />
            <asp:BoundField DataField="ShipState" HeaderText="ShipState" SortExpression="ShipState" />
            <asp:BoundField DataField="ShipZip" HeaderText="ShipZip" SortExpression="ShipZip" />
            <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
            <asp:BoundField DataField="BillAddr1" HeaderText="BillAddr1" SortExpression="BillAddr1" />
            <asp:BoundField DataField="BillAddr2" HeaderText="BillAddr2" SortExpression="BillAddr2" />
            <asp:BoundField DataField="BillCity" HeaderText="BillCity" SortExpression="BillCity" />
            <asp:BoundField DataField="BillState" HeaderText="BillState" SortExpression="BillState" />
            <asp:BoundField DataField="BillZip" HeaderText="BillZip" SortExpression="BillZip" />
            <asp:BoundField DataField="BillCountry" HeaderText="BillCountry" SortExpression="BillCountry" />
            <asp:BoundField DataField="Courier" HeaderText="Courier" SortExpression="Courier" />
            <asp:BoundField DataField="TotalPrice" HeaderText="TotalPrice" SortExpression="TotalPrice" />
            <asp:BoundField DataField="BillToFirstName" HeaderText="BillToFirstName" SortExpression="BillToFirstName" />
            <asp:BoundField DataField="BillToLastName" HeaderText="BillToLastName" SortExpression="BillToLastName" />
            <asp:BoundField DataField="ShipToFirstName" HeaderText="ShipToFirstName" SortExpression="ShipToFirstName" />
            <asp:BoundField DataField="ShipToLastName" HeaderText="ShipToLastName" SortExpression="ShipToLastName" />
            <asp:BoundField DataField="AuthorizationNumber" HeaderText="AuthorizationNumber" SortExpression="AuthorizationNumber" />
            <asp:BoundField DataField="Locale" HeaderText="Locale" SortExpression="Locale" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString3 %>" DeleteCommand="DELETE FROM [Orders] WHERE [OrderId] = @OrderId" InsertCommand="INSERT INTO [Orders] ([UserId], [OrderDate], [ShipAddr1], [ShipAddr2], [ShipCity], [ShipState], [ShipZip], [ShipCountry], [BillAddr1], [BillAddr2], [BillCity], [BillState], [BillZip], [BillCountry], [Courier], [TotalPrice], [BillToFirstName], [BillToLastName], [ShipToFirstName], [ShipToLastName], [AuthorizationNumber], [Locale]) VALUES (@UserId, @OrderDate, @ShipAddr1, @ShipAddr2, @ShipCity, @ShipState, @ShipZip, @ShipCountry, @BillAddr1, @BillAddr2, @BillCity, @BillState, @BillZip, @BillCountry, @Courier, @TotalPrice, @BillToFirstName, @BillToLastName, @ShipToFirstName, @ShipToLastName, @AuthorizationNumber, @Locale)" OnUpdated="SqlDataSource2_Updated" SelectCommand="SELECT * FROM [Orders] WHERE ([OrderId] = @OrderId)" UpdateCommand="UPDATE [Orders] SET [UserId] = @UserId, [OrderDate] = @OrderDate, [ShipAddr1] = @ShipAddr1, [ShipAddr2] = @ShipAddr2, [ShipCity] = @ShipCity, [ShipState] = @ShipState, [ShipZip] = @ShipZip, [ShipCountry] = @ShipCountry, [BillAddr1] = @BillAddr1, [BillAddr2] = @BillAddr2, [BillCity] = @BillCity, [BillState] = @BillState, [BillZip] = @BillZip, [BillCountry] = @BillCountry, [Courier] = @Courier, [TotalPrice] = @TotalPrice, [BillToFirstName] = @BillToFirstName, [BillToLastName] = @BillToLastName, [ShipToFirstName] = @ShipToFirstName, [ShipToLastName] = @ShipToLastName, [AuthorizationNumber] = @AuthorizationNumber, [Locale] = @Locale WHERE [OrderId] = @OrderId">
        <DeleteParameters>
            <asp:Parameter Name="OrderId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UserId" Type="String" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
            <asp:Parameter Name="ShipAddr1" Type="String" />
            <asp:Parameter Name="ShipAddr2" Type="String" />
            <asp:Parameter Name="ShipCity" Type="String" />
            <asp:Parameter Name="ShipState" Type="String" />
            <asp:Parameter Name="ShipZip" Type="String" />
            <asp:Parameter Name="ShipCountry" Type="String" />
            <asp:Parameter Name="BillAddr1" Type="String" />
            <asp:Parameter Name="BillAddr2" Type="String" />
            <asp:Parameter Name="BillCity" Type="String" />
            <asp:Parameter Name="BillState" Type="String" />
            <asp:Parameter Name="BillZip" Type="String" />
            <asp:Parameter Name="BillCountry" Type="String" />
            <asp:Parameter Name="Courier" Type="String" />
            <asp:Parameter Name="TotalPrice" Type="Decimal" />
            <asp:Parameter Name="BillToFirstName" Type="String" />
            <asp:Parameter Name="BillToLastName" Type="String" />
            <asp:Parameter Name="ShipToFirstName" Type="String" />
            <asp:Parameter Name="ShipToLastName" Type="String" />
            <asp:Parameter Name="AuthorizationNumber" Type="Int32" />
            <asp:Parameter Name="Locale" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="OrderId" QueryStringField="OrderId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="UserId" Type="String" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
            <asp:Parameter Name="ShipAddr1" Type="String" />
            <asp:Parameter Name="ShipAddr2" Type="String" />
            <asp:Parameter Name="ShipCity" Type="String" />
            <asp:Parameter Name="ShipState" Type="String" />
            <asp:Parameter Name="ShipZip" Type="String" />
            <asp:Parameter Name="ShipCountry" Type="String" />
            <asp:Parameter Name="BillAddr1" Type="String" />
            <asp:Parameter Name="BillAddr2" Type="String" />
            <asp:Parameter Name="BillCity" Type="String" />
            <asp:Parameter Name="BillState" Type="String" />
            <asp:Parameter Name="BillZip" Type="String" />
            <asp:Parameter Name="BillCountry" Type="String" />
            <asp:Parameter Name="Courier" Type="String" />
            <asp:Parameter Name="TotalPrice" Type="Decimal" />
            <asp:Parameter Name="BillToFirstName" Type="String" />
            <asp:Parameter Name="BillToLastName" Type="String" />
            <asp:Parameter Name="ShipToFirstName" Type="String" />
            <asp:Parameter Name="ShipToLastName" Type="String" />
            <asp:Parameter Name="AuthorizationNumber" Type="Int32" />
            <asp:Parameter Name="Locale" Type="String" />
            <asp:Parameter Name="OrderId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

