$(() => {
    AddButtonsEvents();
    Initialize();
});

function Initialize() {
    console.log(GetStoredMsgs());
}

function ClearChat() {
    $(".chat-content").html("");
}

function AddButtonsEvents() {
    $("#watson-btn").click(() => {
        let storedMsgs = GetStoredMsgs();
        if ([...storedMsgs].length > 0) {
            ClearChat();
            storedMsgs.forEach((msg) => {
                PrintMsg(msg.text, msg.type);
            })
        } else {
            GetWelcomeMessage();
        }
    });

    $("#send-message-btn").click((e) => {
        let input = $("#message-input");
        if (input.val()) {
            SendMsg(input.val());
        }
        input.val("");
    });
}

function appendToChat(element) {
    $(".chat-content").append(element);
    ScrollBottom();
}

/**
 * @param {Array<string>} messages
 * @param {string} type Type of message to be printed "sent" or "received"
 */
function PrintMsg(message, type) {
    let element;
    switch (type) {
        case "sent":
            element = CreateMsgTag(message, "sent");
            appendToChat(element);
            break;
        case "received":
            element = CreateMsgTag(message, "received");
            appendToChat(element);
            break;
        default:
            throw e;
    }
}

function CreateMsgTag(message, type) {
    let div = document.createElement("div");
    div.classList.add("row", "message-container", `base-${type}`);
    div.innerHTML = `
            <div class="col-md-10 col-sm-10">
                <div class="messages message-${type}">
                    <p>${message}</p>
                </div>
            </div>
    `;
    return div;
}

/**
 * @param {string} text
 */
function SendMsg(text) {
    StoreMsg(text, "sent");
    PrintMsg([text], "sent");
    SendWatsonInput(text);
}

/**
 * @param {string} text
 */
function StoreMsg(text, type) {
    let messages = GetStoredMsgs();
    messages.push({ text, type });
    sessionStorage.setItem("chatMessages", JSON.stringify(messages));
}

function GetStoredMsgs() {
    let messages = JSON.parse(sessionStorage.getItem("chatMessages"));
    if (messages) {
        return messages;
    } else {
        return [];
    }
}

function SendWatsonInput(input) {
    let request = new XMLHttpRequest();
    request.open("POST", "/Chat/SendMessage");
    request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    request.onloadstart = () => {
        let element = CreateMsgTag(". . .", "received");
        element.id = "loading";
        appendToChat(element);
    };

    request.onload = () => {
        let responses = JSON.parse(request.responseText);
        responses["results"].forEach((msg) => {
            $("#loading").remove();
            PrintMsg(msg, "received");
            StoreMsg(msg, "received");
        });
    };

    request.send("input=" + input);
}

function GetWelcomeMessage() {
    let request = new XMLHttpRequest();
    request.open("GET", "/Chat/GetWelcomeMessage");
    request.onloadstart = () => {
        let element = CreateMsgTag(". . .", "received");
        element.id = "loading";
        appendToChat(element);
    };

    request.onload = () => {
        $("#loading").remove();
        let message = JSON.parse(request.responseText);
        PrintMsg(message["Message"], "received");
        StoreMsg(message["Message"], "received");
    };

    request.send();
}

function ScrollBottom() {
    document.querySelector(".chat-content").scrollTop = 99999999;
}