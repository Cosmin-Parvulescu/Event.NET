var dhtmlgoodies_slideSpeed = 10; // Higher value = faster
var dhtmlgoodies_timer = 10; // Lower value = faster

var objectIdToSlideDown = false;
var dhtmlgoodies_activeId = false;
var dhtmlgoodies_slideInProgress = false;
var dhtmlgoodies_slideInProgress = false;
var dhtmlgoodies_expandMultiple = false; // true if you want to be able to have multiple items expanded at the same time.

function showHideContent(senderId) {
    if (dhtmlgoodies_slideInProgress) return;
    dhtmlgoodies_slideInProgress = true;

    var inputId = senderId;
    inputId = inputId + '';
    var numericId = inputId.replace(/slideHeader_/g, '');

    var answerDiv = document.getElementById('slideContainer_' + numericId);

    var contentDiv = document.getElementById('slideContent_' + numericId);
    contentDiv.style.top = 0 - contentDiv.offsetHeight + 'px';

    objectIdToSlideDown = false;

    if (!answerDiv.style.display || answerDiv.style.display == 'none') {
        if (dhtmlgoodies_activeId && dhtmlgoodies_activeId != numericId && !dhtmlgoodies_expandMultiple) {
            objectIdToSlideDown = numericId;
            slideContent(dhtmlgoodies_activeId, (dhtmlgoodies_slideSpeed * -1));
        } else {

            answerDiv.style.display = 'block';
            answerDiv.style.visibility = 'visible';

            slideContent(numericId, dhtmlgoodies_slideSpeed);
        }
    } else {
        slideContent(numericId, (dhtmlgoodies_slideSpeed * -1));
        dhtmlgoodies_activeId = false;
    }
}

function slideContent(inputId, direction) {

    var obj = document.getElementById('slideContainer_' + inputId);
    var contentObj = document.getElementById('slideContent_' + inputId);
    height = obj.clientHeight;
    if (height == 0) height = obj.offsetHeight;
    height = height + direction;
    rerunFunction = true;
    if (height > contentObj.offsetHeight) {
        height = contentObj.offsetHeight;
        rerunFunction = false;
    }
    if (height <= 1) {
        height = 1;
        rerunFunction = false;
    }

    obj.style.height = height + 'px';
    var topPos = height - contentObj.offsetHeight;
    if (topPos > 0) topPos = 0;
    contentObj.style.top = topPos + 'px';
    if (rerunFunction) {
        setTimeout('slideContent("' + inputId + '",' + direction + ')', dhtmlgoodies_timer);
    } else {
        if (height <= 1) {
            obj.style.display = 'none';
            if (objectIdToSlideDown && objectIdToSlideDown != inputId) {
                document.getElementById('slideContainer_' + objectIdToSlideDown).style.display = 'block';
                document.getElementById('slideContainer_' + objectIdToSlideDown).style.visibility = 'visible';
                slideContent(objectIdToSlideDown, dhtmlgoodies_slideSpeed);
            } else {
                dhtmlgoodies_slideInProgress = false;
            }
        } else {
            dhtmlgoodies_activeId = inputId;
            dhtmlgoodies_slideInProgress = false;
        }
    }
}