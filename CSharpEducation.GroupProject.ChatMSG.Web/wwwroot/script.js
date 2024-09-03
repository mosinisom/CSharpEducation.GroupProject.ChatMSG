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

function login() {
  // Заглушка для входа
  document.querySelector('.auth').style.display = 'none';
  document.querySelector('.messenger').style.display = 'flex';
}

function loginAsGuest() {
  // Заглушка для входа как гость
  document.querySelector('.auth').style.display = 'none';
  document.querySelector('.messenger').style.display = 'flex';
}

function openChat(chatId) {
  // Заглушка для открытия чата
  document.getElementById('chat-messages').innerHTML = `Сообщения из ${chatId}`;
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


function sendMessage() {
  const messageInput = document.getElementById('message-input');
  const message = messageInput.value;
  if (message.trim() !== '') {
    const chatMessages = document.getElementById('chat-messages');
    const newMessage = document.createElement('div');
    newMessage.textContent = message;
    chatMessages.appendChild(newMessage);
    messageInput.value = '';
  }
}