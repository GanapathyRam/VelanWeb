<%@ Control %>
<%--<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>

<script type="text/javascript">
//<![CDATA[
function Picker1_onSelectionChanged(sender, eventArgs)
{
  sender.AssociatedCalendar.setSelectedDate(sender.getSelectedDate());
}
function Calendar1_onSelectionChanged(sender, eventArgs)
{
  sender.AssociatedPicker.setSelectedDate(sender.getSelectedDate());
}
function Button_OnClick(alignElement, calendar)
{
  if (calendar.get_popUpShowing())
  {
    calendar.hide();
  }
  else
  {
    calendar.setSelectedDate(calendar.AssociatedPicker.getSelectedDate());
    calendar.show(alignElement);
  }
}
function Button_OnMouseUp(calendar, event)
{
  if (calendar.get_popUpShowing())
  {
    event.cancelBubble=true;
    event.returnValue=false;
    return false;
  }
  else
  {
    return true;
  }
}
//]]>
</script>

<table cellspacing="1" cellpadding="0" border="0">
  <tr>
    <td onmouseup="Button_OnMouseUp(<%= Calendar1.ClientObjectId %>, event)"><ComponentArt:Calendar 
      id="Picker1" 
      runat="server" 
      PickerFormat="Custom" 
      PickerCustomFormat="MMMM d yyyy" 
      ControlType="Picker" 
      SelectedDate="2007-01-01"
      PickerCssClass="picker">
      <ClientEvents>
        <SelectionChanged EventHandler="Picker1_onSelectionChanged" />
      </ClientEvents>
      </ComponentArt:Calendar></td>
    <td><img alt="" onmouseup="Button_OnMouseUp(<%= Calendar1.ClientObjectId %>, event)" onclick="Button_OnClick(this, <%= Calendar1.ClientObjectId %>)" class="calendar_button" src="Images/calendar_img.gif" /></td>
  </tr>
</table>
<ComponentArt:Calendar runat="server"
  id="Calendar1" 
  AllowMultipleSelection="false"
  AllowWeekSelection="false"
  AllowMonthSelection="false"
  ControlType="Calendar"
  PopUp="Custom"
  CalendarTitleCssClass="title" 
  SelectedDate="2005-12-13"
  VisibleDate="2005-12-13"
  DayHeaderCssClass="dayheader" 
  DayCssClass="day" 
  DayHoverCssClass="dayhover" 
  OtherMonthDayCssClass="othermonthday" 
  SelectedDayCssClass="selectedday" 
  CalendarCssClass="calendar" 
  NextPrevCssClass="nextprev" 
  MonthCssClass="month"
  SwapSlide="Linear"
  SwapDuration="300"
  DayNameFormat="FirstTwoLetters"
  ImagesBaseUrl="images/"
  PrevImageUrl="prev_mon.gif" 
  NextImageUrl="next_mon.gif"
  >
  <ClientEvents>
    <SelectionChanged EventHandler="Calendar1_onSelectionChanged" />
  </ClientEvents>
</ComponentArt:Calendar>

<script type="text/javascript">
// Associate the picker and the calendar:
function ComponentArt_<%= Calendar1.ClientObjectId %>_Associate()
{
  if (window.<%= Calendar1.ClientObjectId %>_loaded && window.<%= Picker1.ClientObjectId %>_loaded)
  {
    window.<%= Calendar1.ClientObjectId %>.AssociatedPicker = <%= Picker1.ClientObjectId %>;
    window.<%= Picker1.ClientObjectId %>.AssociatedCalendar = <%= Calendar1.ClientObjectId %>;
  }
  else
  {
    window.setTimeout('ComponentArt_<%= Calendar1.ClientObjectId %>_Associate()', 100);
  }
}
ComponentArt_<%= Calendar1.ClientObjectId %>_Associate();
</script>--%>