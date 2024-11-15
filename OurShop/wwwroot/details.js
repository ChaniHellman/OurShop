const welcome=()=>{
    const h1 = document.getElementById("welcomeUser")
    h1.textContent = `Hi ${sessionStorage.getItem("userName")}! you've connected successfuly! let's dive in...`
}

welcome();

const getDataFromDocument = () => {
    fullName = document.querySelector("#fullName").value;
    email = document.querySelector("#email").value;
    password = document.querySelector("#password").value;
    phone = document.querySelector("#phone").value;
    alert("updated successfuly!");
    return { fullName, email, password, phone }
}


const updateUser = async () => {

    const user = getDataFromDocument();

    try {
        const id = sessionStorage.getItem("id")
        const responsePut = await fetch(`api/users/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (!responsePut.ok) {
            alert("An error accured, please try again.")
        }
        else { 
        const dataPut = await responsePut.json();
            console.log('Put data', dataPut)
        }
    }
    catch (error) {
        console.log(error)
    }
}

const showUpdate = () => {

    const UpdateDiv = document.querySelector(".update");
    UpdateDiv.className = "showUpdate";

}