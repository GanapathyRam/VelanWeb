// JScript File

function Grid1_onItemExternalDrop(sender, eventArgs)
{
  var draggedItem = eventArgs.get_item();
  var targetControl = eventArgs.get_targetControl();
  var target = eventArgs.get_target();

  // perform logic
  
  alert(target);
} 


