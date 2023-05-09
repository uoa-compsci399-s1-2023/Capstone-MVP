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
    document.getElementById("details").style.display = "none";
    
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
    document.getElementById("details").style.display = "none";
    
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
    document.getElementById("details").style.display = "none";
    
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
    document.getElementById("details").style.display = "none";
    
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
    document.getElementById("details").style.display = "none";
    
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
    document.getElementById("details").style.display = "none";
    
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
    document.getElementById("details").style.display = "none";
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
    document.getElementById("details").style.display = "none";
    
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
    document.getElementById("details").style.display = "none";
    
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
                //document.getElementById("loginstatus").style.display = "none";
                
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
                //document.getElementById("loginstatus").style.display = "none";
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

const getProject = () => {

    const fetchPromise = fetch('https://localhost:8080/api/ListProjects',
        {
            headers: {
                "Accept": "application/json",

            },
        }
    );
    const Promise = fetchPromise.then((response) => response.json());

    Promise.then((data) => projectInformations(data));
}

const projectInformations = (projects) => {
    let table = "";


    const projectInformation = (project) => {

        ProjectName = project.projectName;
        table += `<div class="box">
                    <a href="#" class="fas fa-heart"></a>
                    <a href="#" class="fas fa-eye" onclick="showDetails(${project.projectName})"></a>
                    <img src="https://localhost:8080/api/ProjectPhoto/${project.projectName}" width="450" alt="">
                    <h3>${project.projectName}</h3>
                    <h4>${project.introduction}</h4>
                    <button onclick="showDetails(ProjectName)">details</button>
                </div>`;
        const contents = document.getElementById("projects");

        contents.innerHTML = table;

    }

    projects.forEach((projects) => projectInformation(projects));
}
const Search = () => {
    let shortcut = document.getElementById("Search").value;

    if (shortcut === "") {
        getProject();
    }
    else {
        const fp = fetch(`https://localhost:8080/api/GetProject/${shortcut}`)

        const sp = fp.then((response) => response.json());

        sp.then((projects) => {
            if (projects.length != 0) {
                projectInformations(projects);

            } else {
                document.getElementById("products").innerHTML = "";
            }
        }
        );

    }
}
const showDetails = (projectName) => {
    document.getElementById("homepage").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("project").style.display = "none";
    document.getElementById("reward").style.display = "none";
    document.getElementById("people").style.display = "none";
    document.getElementById("yourproject").style.display = "none";
    document.getElementById("register").style.display = "none";
    document.getElementById("createteam").style.display = "none";
    document.getElementById("team").style.display = "none";
    document.getElementById("details").style.display = "block";
    
    console.log(projectName);
    const fp = fetch(`https://localhost:8080/api/GetProject/${projectName}`);
    
    const sp = fp.then((response) => response.json());
    
   
    sp.then((data) => projectInformations(data));
    let table = "";
    const projectInformations = (data) => {
        table += `<div class="box">
                    <a class="fa fa-heart" id="heart" onclick="Like(${data.projectID})"></a>
                    <p id="LikeNum"></p>
                    <h3>${data.projectID}</h3>
                    <h3>${data.teamName}</h3>
                    <h3>${data.semester}</h3>
                    <h3>${data.skill}</h3>
                    <h3>${data.approach}</h3>
                    <h3>${data.video}</h3>
                    <h3>${data.client}</h3>
                    <h3>${data.comments}</h3>
                    <h3>${data.likes}</h3>
                    <h3>${data.teamMembers}</h3>
                </div>`;
        //GetLikeNum(data.projectID);
        const contents = document.getElementById("ProjectdetailsTable");
        contents.innerHTML = table;
        

    }
}


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

const showTeams = (items) => {
    let htmlString = `<tr><th>Team</th><th>Teammembers</th></tr>`
    const showItem = (item) => {
        htmlString += `
            <tr>
                <td>
                    <p>${item.teamName}</p>
                    <br/>
                </td>
                <td>
                    <p> ${item.student1} ${item.student2} ${item.student3} ${item.student4} ${item.student5} ${item.student6}</p>
                    <br/>
                </td>
                <td>
                    <button onclick="JoinTeam(${item.teamName})">Join</button>
                </td>
                <br/>
                <td>
                    <button onclick="DeleteTeam(${item.teamName})">Delete</button>
                </td>
        </tr>
        `
        document.getElementById('TeamTable').innerHTML = htmlString;
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

const JoinTeam = (teamname) => {
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
        fetch(`https://localhost:8080/api/JoinTeam`, {
            method: 'POST',
            headers: {
                "authorization": "Basic " + credential,
                "Content-Type": "application/json",
                "accept": 'text/plain',
                'Access-Control-Allow-Origin': 'https://localhost:8080/api/JoinTeam',
                "Access-Control-Allow-Methods": "POST",
                "Access-Control-Allow-Headers": "Content-Type, Authorization"
                
            },
            body: JSON.stringify(teamname)
        }).then(alert("Great! You have successfully joined to this team!"))
    }
}

const DeleteTeam = (teamName) => {
    const Email = document.getElementById("useremaillogin").value;
    const Password = document.getElementById("passwordlogin").value;
    const v = Email + ":" + Password;
    const credential = btoa(v);
    if (adminloginstate === false) {
        alert("Sorry, only admin can delete team!");
    } else {
        fetch(`https://localhost:8080/api/DeleteTeam/${teamName}`, {
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
    }
}

const ProjectUpload= () => {
    if (adminloginstate === false && studentloginstate === false && visitorloginstate === false) {
        alert("Please Log In First!");
        showLogin();
    }
    else if (studentloginstate === false) {
        alert("Sorry, only student can create team!");
        showLogin();
    } else {
        let project = {
            "TeamName": document.getElementById("TeamNameUpload").value,
            "ProjectName": document.getElementById("ProjectNameUpload").value,
            "Skill": document.getElementById("SkillUpload").value,
            "Introduction": document.getElementById("IntroductionUpload").value,
            "Approach": document.getElementById("ApproachUpload").value,
            "Video": document.getElementById("VideoUpload").value
        }
        if (document.getElementById("upload").value != "") {
            uploadimage();
        }
        fetch("https://localhost:8080/api/AddProjects", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "accept": 'text/plain',
                'Access-Control-Allow-Origin': 'https://localhost:8080/api/AddProjects',
                "Access-Control-Allow-Methods": "POST",
                "Access-Control-Allow-Headers": "Content-Type, Authorization"

            },
            body: JSON.stringify(project)
        }).then(alert("Great! You have successfully upload project!"))

    }

}
const  uploadimage =()=> {
    const image = document.getElementById("upload").files[0];
    const formData = new FormData();
    
    formData.append("image", image);
    alert(formData.value);

    const fetchPromise = fetch("https://localhost:8080/api/Uploadimage", {
        method: "POST",
        headers: {
            'Access-Control-Allow-Origin': 'https://localhost:8080/api/Uploadimage',
            "Access-Control-Allow-Methods": "POST",
            "Access-Control-Allow-Headers": "Content-Type, Authorization"
        },
        body: formData,
        
    }
    );
    fetchPromise.onload = function () {
        if (fetchPromise.status === 200) {
            console.log("upload image successfully");
        } else {
            console.error("fail to upload file");
        }
    };
}

function Like(projectID) {
    const heart = document.getElementById('heart');
    if (heart.classList.contains('red')) {
        heart.classList.remove('red');
        const fetchPromise = fetch(`https://localhost:8080/api/UpdateLike?ProjectID=${projectID}&Plus=false`, {
            method: "POST",
            headers: {
                'Access-Control-Allow-Origin': '*',
                "Access-Control-Allow-Methods": "POST",
                "Access-Control-Allow-Headers": "Content-Type, Authorization"
            },
        }
        );
    }
    else{
        heart.classList.add('red');
        const fetchPromise = fetch(`https://localhost:8080/api/UpdateLike?ProjectID=${projectID}&Plus=true`, {
            method: "POST",
            headers: {
                'Access-Control-Allow-Origin': '*',
                "Access-Control-Allow-Methods": "POST",
                "Access-Control-Allow-Headers": "Content-Type, Authorization"
            },
        }
        );
    }

}

function GetLikeNum(projectID) {
    const fetchPromise = fetch('https://localhost:8080/api/GetLikeCount/${projectID}');
    const streamPromise = fetchPromise.then((response) => response.json());
    streamPromise.then((data) => alert(data.value));
}

function changeCss(obj) {
    var alist = document.getElementsByTagName("a");
    obj.style.color = "#ffd800";   //令当前标签高亮
    obj.style.background = "#ffffff";
}

//(function () {
//    const hearts = document.getElementById('heart');
//    hearts.addEventListener('click', function () {
//        hearts.classList.toggle('red');
//    });
//})();

//const ProjectUpload = () => {
//    let user = {
//        //"id": document.getElementById("useridregister").value,
//        "TeamName": document.getElementById("TeamNameUpload").value,
//        "ProjectName": document.getElementById("ProjectNameUpload").value,
//        "Skill": document.getElementById("SkillUpload").value,
//        "Introduction": document.getElementById("IntroductionUpload").value,
//        "Approach": document.getElementById("ApproachUpload").value,
//    }

//    window.addEventListener("load", () => {
//        const input = document.getElementById("upload");
//        const filewrapper = document.getElementById("filewrapper");

//        input.addEventListener("change", (e) => {
//            let fileName = e.target.files[0].name;
//            let filetype = e.target.value.split(".").pop();
//            fileshow(fileName, filetype);
//        })

//        const fileshow = (fileName, filetype) => {
//            const showfileboxElem = document.createElement("div");
//            showfileboxElem.classList.add("showfilebox");
//            const leftElem = document.createElement("div");
//            leftElem.classList.add("left");
//            const fileTypeElem = document.createElement("span");
//            fileTypeElem.classList.add("filetype");
//            fileTypeElem.innerHTML = ("filetype");
//            leftElem.append(fileTypeElem);
//            const filetitleElem = document.createElement("h3");
//            filetitleElem.innerHTML = fileName;
//            leftElem.append(filetitleElem);
//            showfileboxElem.append(leftElem);
//            const rightElem = document.createElement("div");
//            rightElem.classList.add("right");
//            showfileboxElem.append(rightElem);
//            const crossElem = document.createElement("span");
//            crossElem.innerHTML = "&#215;";
//            rightElem.append(crossElem);
//            filewrapper.append(showfileboxElem);

//            crossElem.addEventListener("click", () => {
//                filewrapper.removeChild(showfileboxElem);
//            })
//        }
//    })
//}

const loading = () => {
    getPeoples();
    getTeams();
    showHomePage();
    getProject();
}

window.onload = loading;
