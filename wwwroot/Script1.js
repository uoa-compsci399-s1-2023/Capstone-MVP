const showHomePage = () => {
    document.getElementById("homepage").style.display = "block";
    document.getElementById("login").style.display = "none";
    document.getElementById("project").style.display = "none";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "none";
    document.getElementById("yourproject").style.display = "none";
    document.getElementById("register").style.display = "none";
    document.getElementById("createteam").style.display = "none";
    document.getElementById("team").style.display = "none";
}
const showLogin = () => {
    document.getElementById("homepage").style.display = "none";
    document.getElementById("login").style.display = "block";
    document.getElementById("project").style.display = "none";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "none";
    document.getElementById("yourproject").style.display = "none";
    document.getElementById("register").style.display = "none";
    document.getElementById("createteam").style.display = "none";
    document.getElementById("team").style.display = "none";
}
const showProject = () => {
    document.getElementById("homepage").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("project").style.display = "block";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "none";
    document.getElementById("yourproject").style.display = "none";
    document.getElementById("register").style.display = "none";
    document.getElementById("createteam").style.display = "none";
    document.getElementById("team").style.display = "none";
}
const showReward = () => {
        document.getElementById("homepage").style.display = "none";
        document.getElementById("login").style.display = "none";
        document.getElementById("project").style.display = "none";
        document.getElementById("reward").style.display = "block";
        document.getElementById("people").style.display = "none";
        document.getElementById("yourproject").style.display = "none";
        document.getElementById("register").style.display = "none";
        document.getElementById("createteam").style.display = "none";
        document.getElementById("team").style.display = "none";
}
const showPeople = () => {
    document.getElementById("homepage").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("project").style.display = "none";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "block";
    document.getElementById("yourproject").style.display = "none";
    document.getElementById("register").style.display = "none";
    document.getElementById("createteam").style.display = "none";
    document.getElementById("team").style.display = "none";
}
const showYourProject = () => {
    document.getElementById("homepage").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("project").style.display = "none";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "none";
    document.getElementById("yourproject").style.display = "block";
    document.getElementById("register").style.display = "none";
    document.getElementById("createteam").style.display = "none";
    document.getElementById("team").style.display = "none";
}

const showRegister = () => {
    document.getElementById("homepage").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("project").style.display = "none";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "none";
    document.getElementById("yourproject").style.display = "none";
    document.getElementById("register").style.display = "block";
    document.getElementById("createteam").style.display = "none";
    document.getElementById("team").style.display = "none";
}

const showCreatteam = () => {
    document.getElementById("homepage").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("project").style.display = "none";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "none";
    document.getElementById("yourproject").style.display = "none";
    document.getElementById("register").style.display = "none";
    document.getElementById("createteam").style.display = "block";
    document.getElementById("team").style.display = "none";
}

const showTeam = () => {
    document.getElementById("homepage").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("project").style.display = "none";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "none";
    document.getElementById("yourproject").style.display = "none";
    document.getElementById("register").style.display = "none";
    document.getElementById("createteam").style.display = "none";
    document.getElementById("team").style.display = "block";
}



const UserRegister = () => {
    let user = {
        //"id": document.getElementById("useridregister").value,
        "firstName": document.getElementById("userfirstnameregister").value,
        "lastName": document.getElementById("userlastnameregister").value,
        "email": document.getElementById("useremailregister").value,
        "password": document.getElementById("userpasswordregister").value,
        "interest": document.getElementById("userinterestregister").value,
        //"teamName": document.getElementById("userteamnameregister").value
    }
    var i = document.getElementById("rtypes").value;
    if (i === "Admin") {
        fetch("https://localhost:8080/api/RegisterAdmin", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "accept": 'text/plain',
                'Access-Control-Allow-Origin': 'https://localhost:8080/api/RegisterAdmin',
                "Access-Control-Allow-Methods": "POST",
                "Access-Control-Allow-Headers": "Content-Type, Authorization"

            },
            body: JSON.stringify(user)
        }).then(result => result.text())
            .then((result) => alert(result));
        
    } else if (i === "Student") {
        fetch("https://localhost:8080/api/RegisterStudent", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "accept": 'text/plain',
                'Access-Control-Allow-Origin':'https://localhost:8080/api/RegisterStudent',
            "Access-Control-Allow-Methods": "POST",
            "Access-Control-Allow-Headers": "Content-Type, Authorization"

            },
            body: JSON.stringify(user)
        }).then(result => result.text())
            .then(result => alert(result));
       
    } else {
        fetch("https://localhost:8080/api/RegisterVisitor", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "accept": 'text/plain',
                'Access-Control-Allow-Origin': 'https://localhost:8080/api/RegisterVisitor',
                "Access-Control-Allow-Methods": "POST",
                "Access-Control-Allow-Headers": "Content-Type, Authorization"
                
            },
            body: JSON.stringify(user)
        }).then(result => result.text()).then((result) => alert(result));
        
    }
    showLogin();
       
}
let Email = "";
let Password = "";

const UserLogin = () => {
    const Email = document.getElementById("useremaillogin").value;
    const Password = document.getElementById("passwordlogin").value;
    const v = Email + ":" + Password;
    const credential = btoa(v);
    var l = document.getElementById("ltypes").value;
    if (l === "Admin") {
        const result = fetch("https://localhost:8080/api/GetversionAdmin", {
            headers: {
                "authorization": "Basic " + credential,
            }
        });

        const streamPromise = result.then((response) => {
            if (response.ok) {
                alert("Sucessful Login")
                document.getElementById("loginstatus").innerHTML = `<p align="right" style="color: royalblue">Admin <a onclick = "logout()"> logout<a></p>`;
                adminloginstate = true
                showHomePage();
            }
            else {
                alert("Unsucessful Login");


            }
        });
        
    }
    else if (l === "Student") {
        const result = fetch("https://localhost:8080/api/GetversionStudent", {
            headers: {
                "authorization": "Basic " + credential,
            }
        });

        const streamPromise = result.then((response) => {
            if (response.ok) {
                alert("Sucessful login");
                document.getElementById("loginstatus").innerHTML = `<p align="right" style="color: royalblue">Student <a onclick = "logout()"> logout<a></p>`;
                studentloginstate = true
                showHomePage();
            }
            else {
                alert("Unsucessful Login");


            }
        });
        
    }
    else if (l === "Visitor") {
        const result = fetch("https://localhost:8080/api/GetversionVisitor", {
            headers: {
                "authorization": "Basic " + credential,
            }
        });

        const streamPromise = result.then((response) => {
            if (response.ok) {
                alert("Sucessful login");
                document.getElementById("loginstatus").innerHTML = `<p align="right" style="color: royalblue">Visitor <a onclick = "logout()"> logout<a></p>`;
                visitorloginstate = true
                showHomePage();
            }
            else {
                alert("Unsucessful login");


            }
        });
        
    }


}



const logout = () => {
    adminloginstate = false;
    studentloginstate = false;
    visitorloginstate = false;
    document.getElementById("loginstatus").innerHTML = `<div id="loginstatus" align="right" style="color: royalblue"><a onclick="showLogin()">&#9787 Login &#8659</a></div>`

}

let adminloginstate = false;
let studentloginstate = false;
let visitorloginstate = false;
//let userName = '';
//let passWord = '';

const getPeoples = () => {
    const fetchPromise = fetch('https://localhost:8080/api/ListStudents');
    const streamPromise = fetchPromise.then((response) => response.json());
    streamPromise.then((data) => showPeoples(data));
}

const showPeoples = (items) => {
    let htmlString = `<table><tr><th>Peoples</th><th>interest</th></tr></table>`
    const showItem = (item) => {
        htmlString += `
            <tr>
                <td>
                    <p>${item.firstName} ${item.lastName}</p>
                </td>
                <td>
                    <p>${item.interest}</p>
                </td>
        </tr>
        `
        document.getElementById('PeopleTable').innerHTML = htmlString;
    }
    items.forEach((item) => showItem(item))
}

const searchPeople = () => {
    if (adminloginstate === false && studentloginstate === false && visitorloginstate === false) {
        alert("Please Log In First!");
        showLogin();
    }
    let token = document.getElementById("searchpeopleInput").value;
    console.log(token)
    if (token != '') {
        const fetchPromise = fetch(`https://localhost:8080/api/GetStudentByName${token}`);
        const streamPromise = fetchPromise.then((response) => response.json());
        streamPromise.then((items) => {
            if (items.length == 0) {
                document.getElementById('PeopleTable').innerHTML = "";
            } else {
                showPeoples(items)
            }
        });
    } else {
        getPeoples();
    }
}

const getTeams = () => {
    const fetchPromise = fetch('https://localhost:8080/api/ListTeams');
    const streamPromise = fetchPromise.then((response) => response.json());
    streamPromise.then((data) => showTeams(data));
}

function showTeams(items) {
    
    let htmlString = `<tr><th>Team</th><th>Teammembers</th></tr>`
    const showItem = (item) => {
        TeamName = item.teamName;
        if (item.student1 === "") {
            htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> </p>
                    <br/>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(TeamName)">Delete</button>
                </td>
        </tr>
        `
        } else if (item.student2 === "") {
            htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> ${item.student1}</p>
                    <br/>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(TeamName)">Delete</button>
                </td>
        </tr>
        `
        } else if (item.student3 === "") {
            htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> ${item.student1}, ${item.student2}</p>
                    <br/>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(TeamName)">Delete</button>
                </td>
        </tr>
        `
        } else if (item.student4 === "") {
            htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> ${item.student1}, ${item.student2}, ${item.student3}</p>
                    <br/>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(TeamName)">Delete</button>
                </td>
        </tr>
        `
        } else if (item.student5 === "") {
            htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> ${item.student1}, ${item.student2}, ${item.student3}, ${item.student4}</p>
                    <br/>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(TeamName)">Delete</button>
                </td>
        </tr>
        `
        } else if (item.student5 === "") {
            htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> ${item.student1}, ${item.student2}, ${item.student3}, ${item.student4}</p>
                    <br/>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(TeamName)">Delete</button>
                </td>
        </tr>
        `
        } else if (item.student6 === "") {
            htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> ${item.student1}, ${item.student2}, ${item.student3}, ${item.student4}</p>
                    <br/>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(TeamName)">Delete</button>
                </td>
        </tr>
        `
        }else {
            htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> ${item.student1}, ${item.student2}, ${item.student3}, ${item.student4}, ${item.student5}, ${item.student6}</p>
                    <br/>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(TeamName)">Delete</button>
                </td>
        </tr>
        `
        }
        document.getElementById('TeamTable').innerHTML = htmlString;
        console.log(TeamName)
    }
    items.forEach((item) => showItem(item))
}

const searchTeam = () => {
    if (adminloginstate === false && studentloginstate === false && visitorloginstate === false) {
        alert("Please Log In First!");
        showLogin();
    }
    let token = document.getElementById("searchteamInput").value;
    console.log(token)
    if (token != '') {
        const fetchPromise = fetch(`https://localhost:8080/api/GetTeamByName${token}`);
        const streamPromise = fetchPromise.then((response) => response.json());
        streamPromise.then((items) => {
            if (items.length == 0) {
                document.getElementById('TeamTable').innerHTML = "";
            } else {
                showTeams(items)
            }
        });
    } else {
        getTeams();
    }
}

const JoinTeam = () => {
    if (adminloginstate === false && studentloginstate === false && visitorloginstate === false) {
        alert("Please log in first!");
        showLogin();
    } else if (studentloginstate === false) {
        alert("Sorry, only students can join a team!");
    } else {
        const Email = document.getElementById("useremaillogin").value;
        const Password = document.getElementById("passwordlogin").value;
        const v = Email + ":" + Password;
        const credential = btoa(v);
        let team = {
            "TeamName": document.getElementById("jointeamInput").value
        }
        fetch("https://localhost:8080/api/JoinTeam", {
            method: 'POST',
            headers: {
                "authorization": "Basic " + credential,
                "Content-Type": "application/json",
                "accept": 'text/plain',
                'Access-Control-Allow-Origin': 'https://localhost:8080/api/JoinTeam',
                "Access-Control-Allow-Methods": "POST",
                "Access-Control-Allow-Headers": "Content-Type, Authorization"

            },
            body: JSON.stringify(team)
        }).then(alert("Great! You have successfully joined to this team!"));
        document.getElementById("jointeamInput").value = "";
    }
}

function DeleteTeam(TeamName) {
    const Email = document.getElementById("useremaillogin").value;
    const Password = document.getElementById("passwordlogin").value;
    const v = Email + ":" + Password;
    const credential = btoa(v);
    if (adminloginstate === false) {
        alert("Sorry, only admin can delete team!");
    } else {
        fetch(`https://localhost:8080/api/DeleteTeam/${TeamName}`, {
            method: 'DELETE',
            headers: {
                
                "authorization": "Basic " + credential,
            }
        }).then(result => result.text())
            .then((result) => alert(result));
    }
}

const CreateTeam = () => {
    if (adminloginstate === false && studentloginstate === false && visitorloginstate === false) {
        alert("Please Log In First!");
        showLogin();
    }
    else if (adminloginstate === false) {
        alert("Sorry, only admin can create team!");
        showLogin();
    } else{
        let team = {
            "TeamName": document.getElementById("createteamname").value,
            "Student1": document.getElementById("createstudent1").value,
            "Student2": document.getElementById("createstudent2").value,
            "Student3": document.getElementById("createstudent3").value,
            "Student4": document.getElementById("createstudent4").value,
            "Student5": document.getElementById("createstudent5").value,
            "Student6": document.getElementById("createstudent6").value,
        }
        fetch("https://localhost:8080/api/AddTeams", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "accept": 'text/plain',
                'Access-Control-Allow-Origin': 'https://localhost:8080/api/AddTeams',
                "Access-Control-Allow-Methods": "POST",
                "Access-Control-Allow-Headers": "Content-Type, Authorization"

            },
            body: JSON.stringify(team)
        }).then(alert("Great! You have successfully created this team!"))
        showTeam();
        document.getElementById("createteamname").value = "";
        document.getElementById("createstudent1").value = "";
        document.getElementById("createstudent2").value = "";
        document.getElementById("createstudent3").value = "";
        document.getElementById("createstudent4").value = "";
        document.getElementById("createstudent5").value = "";
        document.getElementById("createstudent6").value = ""

    }
}

function Like(clicked_id) {
    const heartIcon = document.getElementById(clicked_id);
    let b = new Boolean(heartIcon.style.color == "red");
    alert(heartIcon.parentElement.id);

}

const loading = () => {
    getPeoples();
    getTeams();
    showHomePage();
}

window.onload = loading;
