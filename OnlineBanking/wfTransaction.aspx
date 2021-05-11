<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfTransaction.aspx.cs" Inherits="OnlineBanking.wfTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number:"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblBalance" runat="server" Text="Balance:"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblTransactionType" runat="server" Text="Transaction Type:"></asp:Label>
&nbsp;&nbsp;
    <asp:DropDownList ID="ddlTransferType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTransferType_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblAmount" runat="server" Text="Amount:"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="tbAmount" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <p>
        <asp:Label ID="lblTo" runat="server" Text="To:"></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPayee" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:LinkButton ID="lnkbtnCompleteTransaction" runat="server" OnClick="lnkbtnCompleteTransaction_Click">Complete Transaction</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbtnAccountHistory" runat="server" OnClick="lnkbtnAccountHistory_Click">Return to Account History</asp:LinkButton>
    </p>
    <p>
        &nbsp;</p>
    <p>
    <asp:RangeValidator ID="RangeValidator" runat="server" ControlToValidate="tbAmount" Display="Dynamic" ErrorMessage="Amount must be between 0.01 and 10,000.00" MaximumValue="100000.00" MinimumValue="0.01" Type="Double"></asp:RangeValidator>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    </asp:Content>
