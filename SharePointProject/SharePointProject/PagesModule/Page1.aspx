<%@ MasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="CustomControls" Namespace="SharePointProject.CustomControls" Assembly="$SharePoint.Project.AssemblyFullName$" %>

<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <p>This is sample content</p>
    <CustomControls:CurrentUserControl runat="server" ID="CurrentUserControl1" />
</asp:Content>
