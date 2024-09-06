let currentChatId = null;
let currentUserId = null;

function showLoginForm() {
    document.getElementById('login-form').style.display = 'block';
    document.getElementById('register-form').style.display = 'none';
    document.getElementById('guest-form').style.display = 'none';
}

function showRegisterForm() {
    document.getElementById('login-form').style.display = 'none';
    document.getElementById('register-form').style.display = 'block';
    document.getElementById('guest-form').style.display = 'none';
}

function register() {
    const registerUsername = document.getElementById('register-username');
    const registerPassword = document.getElementById('register-password');

    const data = {
        "userName": registerUsername.value,
        "password": registerPassword.value,
    }
    const response = fetch('/User', {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    }).then(r => {
        if (r.ok) {
            alert('Вы зарегестрированы');
            showLoginForm();
        }
        else alert('Произошла ошибка');
    });
}

function login() {
    const loginUsername = document.getElementById('login-username');
    const loginPassword = document.getElementById('login-password');

    const data = {
        "userName": loginUsername.value,
        "password": loginPassword.value,
    }
    fetch('/User/login', {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    })
        .then(response => {
            if (response.ok) {
                alert('Вы вошли в систему');
                document.querySelector('.auth').style.display = 'none';
                document.querySelector('.messenger').style.display = 'flex';
            } else {
                alert('Произошла ошибка при входе');
            }
        })
        .catch(error => console.error('Ошибка при входе:', error));
}

document.addEventListener("DOMContentLoaded", () => {
    const chatList = document.getElementById("chatList");
    const messageList = document.getElementById("messageList");
    const messageInput = document.getElementById("messageInput");
    const sendButton = document.getElementById("sendButton");
    const chatNameInput = document.getElementById("chat-name-input");
    let currentChatId = null;

    // Функция для загрузки всех чатов
function loadChats() {
    fetch('/Chats') // Получаем список чатов через контроллер Chats
        .then(response => response.json())
        .then(data => {
            const chatList = document.getElementById("chatList");
            chatList.innerHTML = ''; // Очищаем список чатов перед отображением новых
            data.forEach(chat => {
                const chatTab = document.createElement("div");
                chatTab.textContent = chat.name;
                chatTab.classList.add('chat-tab'); // Применяем класс для вкладки
                
                // Добавляем событие клика на каждую вкладку
                chatTab.addEventListener("click", () => {
                    console.log(`Chat clicked: ${chat.id}`);
                    currentChatId = chat.id;
                    loadMessages(currentChatId);
                });
                chatList.appendChild(chatTab); // Добавляем вкладку в список
            });
        })
        .catch(error => console.error('Ошибка при загрузке чатов:', error));
    }

    // Функция для создания нового чата
    function createChat() {
        const chatName = chatNameInput.value;
        if (!chatName) {
            return; // Если название чата пустое
        }

        fetch('/Chats', { // Отправляем данные нового чата
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ name: chatName }),
        })
            .then(response => response.json())
            .then(data => {
                // После успешного создания чата обновляем список чатов
                const chatTab = document.createElement("div");
                chatTab.textContent = data.name;
                chatTab.addEventListener("click", () => {
                    currentChatId = data.id;
                    loadMessages(currentChatId);
                });
                chatTab.classList.add('chat-tab');
                chatList.appendChild(chatTab);
                chatNameInput.value = ''; // Очищаем поле ввода
            })
            .catch(error => console.error('Ошибка при создании чата:', error));
    }

    // Функция для загрузки сообщений по ID чата
    function loadMessages(chatId) {
        if (!chatId) { return; }
        fetch(`/Messages/${currentChatId}`) // Изменено на правильный маршрут
            .then(response => response.json())
            .then(data => {
                messageList.innerHTML = ''; // Очищаем список сообщений перед отображением новых
                data.forEach(message => {
                    const messageItem = document.createElement("li");
                    messageItem.textContent = `${message.userName} ${message.dateTime}: ${message.content}`; // Обновлено для корректного отображения
                    messageList.appendChild(messageItem);
                });
            })
            .catch(error => console.error('Ошибка при загрузке сообщений:', error));
    }

    // Функция для отправки сообщения
    sendButton.addEventListener("click", () => {
        if (!currentChatId || !messageInput.value) {
            return; // Если чат не выбран или сообщение пустое
        }

        const messageData = {
            chatId: currentChatId,
            content: messageInput.value, // Используем content вместо text
        };

        fetch('/Messages', { // Отправляем сообщение через контроллер Messages
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(messageData),
        })
            .then(response => response.json())
            .then(data => {
                // После успешной отправки сообщения обновляем список сообщений
                const messageItem = document.createElement("li");
                messageItem.textContent = `${data.userName} ${data.dateTime}: ${data.content}`; // Обновлено для корректного отображения
                messageList.appendChild(messageItem);
                messageInput.value = ''; // Очищаем поле ввода
            })
            .catch(error => console.error('Ошибка при отправке сообщения:', error));
    });

   

    loadChats();
    setInterval(() => loadMessages(currentChatId), 2500);
    setInterval(() => loadChats(), 2500);

    document.getElementById("createChatButton").addEventListener("click", createChat);
});


