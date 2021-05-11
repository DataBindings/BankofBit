<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfAccount.aspx.cs" Inherits="OnlineBanking.wfAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblFullName" runat="server" Font-Bold="True" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblAccountNumber" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblBalance" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvAccount" runat="server" AutoGenerateColumns="False" Width="560px">
            <Columns>
                <asp:BoundField DataField="DateCreated" HeaderText="Date" DataFormatString="{0:d}" />
                <asp:BoundField DataField="TransactionType.Description" HeaderText="Transaction Type" />
                <asp:BoundField DataField="Deposit" DataFormatString="{0:C}" HeaderText="Amount In">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Withdrawal" DataFormatString="{0:C}" HeaderText="Amount Out">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Notes" HeaderText="Details" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:LinkButton ID="lnkbtnTransactionWebForm" runat="server" OnClick="lnkbtnTransactionWebForm_Click">Pay Bills and Transfer Funds</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbtnClientWebForm" runat="server" OnClick="lnkbtnClientWebForm_Click">Return to Bank Account List</asp:LinkButton>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
</asp:Content>
