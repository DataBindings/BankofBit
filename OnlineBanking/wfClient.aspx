<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfClient.aspx.cs" Inherits="OnlineBanking.wfClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblFullName" runat="server" Text="Label" Font-Bold="True"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvClient" runat="server" AutoGenerateSelectButton="True" Height="168px" HorizontalAlign="Left" Width="560px" AutoGenerateColumns="False" OnSelectedIndexChanged="gvClient_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                <asp:BoundField DataField="Notes" HeaderText="Account Notes" />
                <asp:BoundField DataField="Balance" DataFormatString="{0:C}" HeaderText="Balance">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </P>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
</asp:Content>