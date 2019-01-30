// JScript File
function togglePanel(panel) {
    if(document.getElementById(panel).className=="panelNormal") {
        document.getElementById(panel).className="panelClosed";
        document.getElementById("collapseImg").src="images/collapse_down.gif";
        }
      else {
      document.getElementById(panel).className="panelNormal";
      document.getElementById("collapseImg").src="images/collapse_up.gif";
    }
}


