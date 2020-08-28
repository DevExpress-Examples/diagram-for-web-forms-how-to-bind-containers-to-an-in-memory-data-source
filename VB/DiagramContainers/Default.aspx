<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="DiagramContainers.Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxDiagram.v20.1, Version=20.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDiagram" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxDiagram ID="Diagram" runat="server" NodeDataSourceID="NodeDataSource" 
            Width="100%" Height="600px" SimpleView="true">
            <Mappings>
                <Node Key="ID" ContainerKey="ContainerID" Type="Type" Text="Text" 
                    Left="X" Top="Y" Width="Width" Height="Height" />
            </Mappings>
            <SettingsToolbox>
                <Groups>
                    <dx:DiagramToolboxGroup Category="General" />
                    <dx:DiagramToolboxGroup Category="Containers" />
                </Groups>
            </SettingsToolbox>
        </dx:ASPxDiagram>

        <asp:ObjectDataSource ID="NodeDataSource" runat="server" 
            TypeName="DiagramContainers.DiagramDataProvider" 
            DataObjectTypeName="DiagramContainers.Item"
            SelectMethod="GetItems" 
            InsertMethod="InsertItem"
            UpdateMethod="UpdateItem"
            DeleteMethod="DeleteItem">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
