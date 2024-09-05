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

function showGuestForm() {
  document.getElementById('login-form').style.display = 'none';
  document.getElementById('register-form').style.display = 'none';
  document.getElementById('guest-form').style.display = 'block';
}


function loginAsGuest() {
  // Заглушка для входа как гость
  document.querySelector('.auth').style.display = 'none';
  document.querySelector('.messenger').style.display = 'flex';
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
            alert('Вы зарегистрированы');
            showLoginForm();
        }
        else alert('Произошла ошибка при регистрации');
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
  }).then(r => r.json())
    .then(response => {
      if (response.userId) {
        currentUserId = response.userId;
        alert('Вы вошли в систему');
        document.querySelector('.auth').style.display = 'none';
        document.querySelector('.messenger').style.display = 'flex';
        getAllChats();
      } else {
        alert('Произошла ошибка при входе');
      }
    })
    .catch(error => console.error('Ошибка при входе:', error));
}

function getAllChats() {
  fetch('/Chats')
    .then(response => response.json())
    .then(chats => {
      const chatList = document.querySelector('.chat-list');
      chatList.innerHTML = '';
      chats.forEach(chat => {
        const chatItem = document.createElement('div');
        chatItem.className = 'chat-item';
        chatItem.textContent = chat.name;
        chatItem.onclick = () => openChat(chat.id);
        chatList.appendChild(chatItem);
      });
    })
    .catch(error => console.error('Ошибка при получении чатов:', error));
}

function createChat() {
  const chatNameInput = document.getElementById('chat-name-input');
  const chatName = chatNameInput.value;

  if (chatName.trim() !== '') {
    const data = {
      "name": chatName,
    };

    fetch('/Chats', {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then(response => response.json())
      .then(chat => {
        alert('Чат создан');
        getAllChats(); 
        chatNameInput.value = '';
      })
      .catch(error => console.error('Ошибка при создании чата:', error));
  } else {
    alert('Введите название чата');
  }
}

function openChat(chatId) {
  currentChatId = chatId;
  fetch('/Messages/chats', {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ id: chatId }),
  })
    .then(response => response.json())
    .then(messages => {
      const chatMessages = document.getElementById('chat-messages');
      chatMessages.innerHTML = '';
      messages.forEach(message => {
        const messageElement = document.createElement('div');
        messageElement.textContent = message.content;
        chatMessages.appendChild(messageElement);
      });
    })
    .catch(error => console.error('Ошибка при открытии чата:', error));
}

function sendMessage() {
  const messageInput = document.getElementById('message-input');
  const message = messageInput.value;

  if (message.trim() !== '') {
    const data = {
      "chatId": currentChatId, 
      "content": message,
      "userId": currentUserId,
    };

    fetch('/Messages', {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then(response => response.json())
      .then(newMessage => {
        const chatMessages = document.getElementById('chat-messages');
        const messageElement = document.createElement('div');
        messageElement.textContent = newMessage.content;
        chatMessages.appendChild(messageElement);
        messageInput.value = ''; 
      })
      .catch(error => console.error('Ошибка при отправке сообщения:', error));
  } else {
    alert('Введите сообщение');
  }
}