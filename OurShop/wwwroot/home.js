

const getDataFromDocument = () => {
    fullName = document.querySelector("#fullName").value;
    email = document.querySelector("#email").value;
    password = document.querySelector("#password").value;
    phone = document.querySelector("#phone").value;
    return { fullName, email, password, phone }
}

const createUser = async () => {
    const user = getDataFromDocument();
    try {
        const responsePost = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        })
        if (!responsePost.ok) {
            alert("Cannot create user. please try again.")
        }
        else { 
            const postData = await responsePost.json();
            alert(`User: ${postData.fullName} created!`)
            checkPasswordStrength(user.password);
        }
        
    }
    catch (error) {
        console.log(error)
    }
}

const getDataFromLogIn = () => {
    email = document.querySelector("#loginEmail").value;
    password = document.querySelector("#loginPassword").value;

    return { email, password }
}

const login = async () => {

    const data = getDataFromLogIn();

    try {
        const responsePost = await fetch(`api/users/login/?email=${data.email}&password=${data.password}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                email: data.email,
                password: data.password
            }
        })
        if (responsePost.status == 204) {
            alert("User not found")
        }
        if (!responsePost.ok) {
            alert("An error accured, please try again.")
        }
        else { 
        const postData = await responsePost.json();
        console.log('post data:', postData)
        sessionStorage.setItem("id", postData.userId)
        sessionStorage.setItem("userName", postData.fullName)

            window.location.href = "details.html"
        }
    }
    catch (error) {
        console.log(error)
    }
}

const showSignUp = () => {
    const signUpDiv = document.querySelector(".signUp");
    signUpDiv.className = "showSignUp";

}

const checkPasswordStrength = async (password) => {
    try {
        const passwordStrength = await fetch(`api/users/passwordStrength/?password=${password}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                password: password
            }
        }); 
        const p = await passwordStrength.json()
        console.log(p); 
        return p;
    }
     catch (error) {
        console.log(error)
    }

    
}

const fillProgress = async () => {
    const progress = document.getElementById("progress");
    const password = document.getElementById("password").value;
    const strength = await checkPasswordStrength(password);
    progress.value = strength;

}







