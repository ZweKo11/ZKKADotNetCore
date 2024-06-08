const tblBlog = "Blogs";
let blogId = null;
getBlogsTable();

// readBlog();
// createBlog();
//updateBlog("c714d658-3bc8-4058-b153-275b249e1f31","Title 1", "Author 1", "Content 1");
//deleteBlog("3ed13f5c-241b-4006-8a19-cd18beda3f61");

function readBlog(){
    let lst = getBlogs();
    console.log(lst);
}

function createBlog(title, author, content){
    let lst = getBlogs();

    const requestModel = {
        id : uuidv4(),
        title : title,
        author : author,
        content : content
    }
    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Saving is successful!");
    clearControls();
}

function editBlog(id){
    let lst = getBlogs();

    const items = lst.filter(x => x.id === id);

    if(items.length === 0){
        console.log("No data Found!");
        errorMessage("No data found");
        return;
    }

    let item = items[0];
    blogId = item.id;
    $("#txtTitle").val(item.title);
    $("#txtAuthor").val(item.author);
    $("#txtContent").val(item.content);

    $("#txtTitle").focus();
}

function updateBlog(id, title, author, content){
    let lst = getBlogs();

    const items = lst.filter(x => x.id === id);
    console.log(items);
    console.log(items.length);

    if(items.length === 0){
        console.log("No data Found!");
        return;
    }

    const item = items[0];
    item.title = title,
    item.author = author,
    item.content = content

    const index = lst.findIndex(x=> x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    successMessage("Updating successful");
}

function deleteBlog(id){
    // const result = confirm("Are you sure to delete this blog?");
    // if(!result) return;

    Notiflix.Confirm.show(
        'Notiflix Confirm',
        'Do you agree with me?',
        'Yes',
        'No',
        function okCb() {
            let lst = getBlogs();

            const items = lst.filter(x => x.id === id);

            if(items.length === 0){
                console.log("No data Found!");
                return;
            }

            lst = lst.filter(x => x.id !== id);
            const jsonBlog = JSON.stringify(lst);
            localStorage.setItem(tblBlog, jsonBlog);

            successMessage("Deleting is successful");
            getBlogsTable();
        },
        function cancelCb() {
            alert('If you say so...');
        },
        {
        },
    );
}

function getBlogs(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }
    return lst;
}

//Id creation function
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }

//create blog  
$("#btnSave").click(function(){
    console.log("hello");
    let title = $("#txtTitle").val();
    let author = $("#txtAuthor").val();
    let content = $("#txtContent").val();

    if(blogId === null){
        createBlog(title, author, content);
    }else{
        updateBlog(blogId, title, author, content);
        blogId = null;
    }
    getBlogsTable();
})

//read blog
function getBlogsTable(){
    let lst = getBlogs();
    let count = 0;
    let htmlRows = '';

    lst.forEach(item => {
        let htmlRow = `
            <tr>
                <td>${++count}</td>
                <td>${item.title}</td>
                <td>${item.author}</td>
                <td>${item.content}</td>
                <td>
                    <button class="btn btn-warning text-white" onclick="editBlog('${item.id}')">Edit</button>
                    <button class="btn btn-danger text-white" onclick="deleteBlog('${item.id}')">Delete</button>
                </td>
            </tr>
        `;
        htmlRows += htmlRow;
    });

    $('#tbody').html(htmlRows);
}

function successMessage(message){
    Swal.fire({
        title: "Success",
        text: message,
        icon: "success"
      });
}

function errorMessage(message){
    Swal.fire({
        title: "Error!",
        text: message,
        icon: "error"
      });
}

function clearControls(){
    $("#txtTitle").val('');
    $("#txtAuthor").val('');
    $("#txtContent").val('');

    $("#txtTitle").focus();
}