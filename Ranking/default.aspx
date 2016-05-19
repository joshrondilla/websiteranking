<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Ranking._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ranking</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
        <div>
            Top 5 Websites Ranking
            
            <asp:UpdatePanel runat="server" ID="uplTop5">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                </Triggers>
                <ContentTemplate>
            <table>
                <tr>
                    <td>
                        from <asp:Calendar runat="server" ID="calFrom" ></asp:Calendar>
                    </td>
                    <td>
                        until <asp:Calendar runat="server" ID="calUntil"></asp:Calendar>
                    </td>
                </tr>
            </table>
            <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_OnClick" Text="search" />
                    <table>
                        <tr>
                            <td>Website</td>
                            <td>Visits</td>
                        </tr>
                        <asp:ListView runat="server" ID="lstTop5">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("Name")%><br />
                                    </td>
                                    <td>
                                        <%#Eval("Visits")%><br />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress runat="server" ID="uprTop5" AssociatedUpdatePanelID="uplTop5" ></asp:UpdateProgress>
        
           
        </div>
    </form>
</body>
</html>
