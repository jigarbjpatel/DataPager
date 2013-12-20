<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataPager.ascx.cs" Inherits="pSale.UserControls.DataPager" %>
<table>
    <tr>
        <td width="10%"></td>
        <td width="30%">
            Showing records <asp:Label ID="lblStartRecordNumber" runat="server" CssClass="dpNumbers"/> to <asp:Label ID="lblEndRecordNumber" runat="server" CssClass="dpNumbers" /> of <asp:Label ID="lblTotalRecords" runat="server" CssClass="dpNumbers" /> 
        </td>
        <td width="20%">Page <asp:Label ID="lblCurrentPageNumber" runat="server" CssClass="dpNumbers"/> of <asp:Label ID="lblTotalPages" runat="server" CssClass="dpNumbers"/></td>
        <td width="3%">
            <asp:LinkButton ID="lnkFirst" runat="server" onclick="lnkFirst_Click">First</asp:LinkButton>
        </td>
        <td width="3%">
            <asp:LinkButton ID="lnkPrev" runat="server" onclick="lnkPrev_Click">Prev</asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton ID="lnkPrevPages" runat="server" onclick="lnkPrevPages_Click">...</asp:LinkButton>
            <asp:LinkButton ID="lnk1" runat="server" onclick="lnkSpecificPage_Click"></asp:LinkButton>
            <asp:LinkButton ID="lnk2" runat="server" onclick="lnkSpecificPage_Click"></asp:LinkButton>
            <asp:LinkButton ID="lnk3" runat="server" onclick="lnkSpecificPage_Click"></asp:LinkButton>
            <asp:LinkButton ID="lnk4" runat="server" onclick="lnkSpecificPage_Click"></asp:LinkButton>
            <asp:LinkButton ID="lnk5" runat="server" onclick="lnkSpecificPage_Click"></asp:LinkButton>
            <asp:LinkButton ID="lnkNextPages" runat="server" onclick="lnkNextPages_Click">...</asp:LinkButton>
        </td>
        <td width="3%">
            <asp:LinkButton ID="lnkNext" runat="server" onclick="lnkNext_Click">Next</asp:LinkButton>
        </td>
        <td width="3%">
            <asp:LinkButton ID="lnkLast" runat="server" onclick="lnkLast_Click">Last</asp:LinkButton>
        </td>
        <td width="10%"></td>
    </tr>
</table>
<asp:HiddenField ID="hidPageSize" runat="server" />
<asp:HiddenField ID="hidStartPageNumber" runat="server" />
<asp:HiddenField ID="hidEndPageNumber" runat="server" />