/* File Created: June 26, 2012 */
$.fn.dataTableExt.oApi.fnAddDataAndDisplay = function (oSettings, aData) {
    /* Add the data */
    var iAdded = this.oApi._fnAddData(oSettings, aData);
    var nAdded = oSettings.aoData[iAdded].nTr;

    /* Need to re-filter and re-sort the table to get positioning correct, not perfect
    * as this will actually redraw the table on screen, but the update should be so fast (and
    * possibly not alter what is already on display) that the user will not notice
    */
    this.oApi._fnReDraw(oSettings);

    /* Find it's position in the table */
    var iPos = -1;
    for (var i = 0, iLen = oSettings.aiDisplay.length; i < iLen; i++) {
        if (oSettings.aoData[oSettings.aiDisplay[i]].nTr == nAdded) {
            iPos = i;
            break;
        }
    }

    /* Get starting point, taking account of paging */
    if (iPos >= 0) {
        oSettings._iDisplayStart = (Math.floor(i / oSettings._iDisplayLength)) * oSettings._iDisplayLength;
        this.oApi._fnCalculateEnd(oSettings);
    }

    this.oApi._fnDraw(oSettings);

    // play animation on added tr
    $(nAdded)
        .animate({ backgroundColor: '#acfa58' }, 1500)
        .animate({ backgroundColor: 'transparent' }, 1500);  

    return {
        "nTr": nAdded,
        "iPos": iAdded
    };
};


$.fn.dataTableExt.oApi.fnGetHiddenNodes = function (oSettings) {
    /* Note the use of a DataTables 'private' function thought the 'oApi' object */
    var anNodes = this.oApi._fnGetTrNodes(oSettings);
    var anDisplay = $('tbody tr', oSettings.nTable);

    /* Remove nodes which are being displayed */
    for (var i = 0; i < anDisplay.length; i++) {
        var iIndex = jQuery.inArray(anDisplay[i], anNodes);
        if (iIndex != -1) {
            anNodes.splice(iIndex, 1);
        }
    }

    /* Fire back the array to the caller */
    return anNodes;
};

