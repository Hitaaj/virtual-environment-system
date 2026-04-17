<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="calendar.aspx.cs" Inherits="ves230325287.calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.calendar-container {
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
    background-color: #f8f9fa;
    border-radius: 8px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.calendar-header {
    text-align: center;
    margin-bottom: 20px;
}

.calendar-header h2 {
    font-size: 24px;
    color: #343a40;
}

.calendar-body {
    margin-bottom: 20px;
}

.custom-calendar {
    width: 100%;
    border: none;
}

.calendar-day {
    padding: 10px;
    text-align: center;
}

.selected-day {
    background-color: #007bff !important;
    color: white !important;
}

.weekend-day {
    background-color: #f1f1f1;
}

.calendar-info {
    margin-top: 20px;
}

.info-label {
    display: block;
    font-size: 16px;
    margin-bottom: 10px;
    color: #495057;
}

.events-grid {
    width: 100%;
    border-collapse: collapse;
}

.events-grid th, .events-grid td {
    padding: 10px;
    border: 1px solid #dee2e6;
    text-align: left;
}

.events-grid th {
    background-color: #007bff;
    color: white;
}

.events-grid tr:nth-child(even) {
    background-color: #f8f9fa;
}

.events-grid tr:hover {
    background-color: #e9ecef;
}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br /><br /><br /><br /><br />
  <div class="calendar-container">
        <div class="calendar-header">
            <h2>Event Calendar</h2>
        </div>
        <div class="calendar-body">
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"
                          CssClass="custom-calendar" DayStyle-CssClass="calendar-day" 
                          SelectedDayStyle-CssClass="selected-day" WeekendDayStyle-CssClass="weekend-day">
            </asp:Calendar>
        </div>
        <div class="calendar-info">
            <asp:Label ID="Label1" runat="server" Text="" CssClass="info-label"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" CssClass="events-grid">
            </asp:GridView>
        </div>
    </div>
</asp:Content>

