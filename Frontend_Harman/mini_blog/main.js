const BASE_URL = "https://jsonplaceholder.typicode.com";
const totalPages = 10; // total pages based on JSONPlaceholder
const visiblePages = 5; // how many page numbers to display at a time
let currentPage = 1; // current page number
let controller = null;

// API helper
const apiFetch = async (endpoint, options = {}) => {
    if (controller) controller.abort();
    controller = new AbortController();
    options.signal = controller.signal;

    if (options.body && typeof options.body === "object") {
        options.headers = { "Content-Type": "application/json" };
        options.body = JSON.stringify(options.body);
    }

    try {
        const res = await fetch(`${BASE_URL}${endpoint}`, options);
        if (!res.ok) throw new Error(`Error: ${res.status}`);
        return await res.json();
    } catch (err) {
        console.error(err.message);
        alert(err.message);
    }
};

// Render posts
const renderPosts = (posts) => {
    const list = document.getElementById("posts-list");
    list.innerHTML = posts.map(({ id, title, body }) => `
        <div class="col-md-6">
            <div class="card h-100">
                <div class="card-body">
                    <h5 class="card-title">${title}</h5>
                    <p class="card-text">${body.slice(0, 60)}...</p>
                    <button class="btn btn-sm btn-warning me-2 edit-btn" data-id="${id}">Edit</button>
                    <button class="btn btn-sm btn-danger delete-btn" data-id="${id}">Delete</button>
                </div>
            </div>
        </div>
    `).join("");
};

// Load posts (GET)
const getPosts = async (page = 1) => {
    document.getElementById("posts-list").innerHTML = `<p>Loading...</p>`;
    const posts = await apiFetch(`/posts?_page=${page}&_limit=10`);
    renderPosts(posts ?? []);
    renderPagination();

};

// Form submit handler (POST or PUT)
document.getElementById("post-form").addEventListener("submit", async (e) => {
    e.preventDefault();
    const id = document.getElementById("post-id").value;
    const title = document.getElementById("title").value.trim();
    const body = document.getElementById("body").value.trim();

    if (!title || !body) return alert("Please fill all fields");

    if (id) {
        // Update post (PUT)
        const updatedPost = await apiFetch(`/posts/${id}`, { 
            method: "PUT", 
            body: { title, body, userId: 1 } 
        });

        alert("Post updated!");

        // Update UI immediately without reload
        const card = document.querySelector(`.edit-btn[data-id="${id}"]`)?.closest(".card");
        if (card) {
            card.querySelector(".card-title").textContent = updatedPost?.title ?? title;
            card.querySelector(".card-text").textContent = (updatedPost?.body ?? body).slice(0, 60) + "...";
        }
    } else {
        // Create post (POST)
        const newPost = await apiFetch(`/posts`, { 
            method: "POST", 
            body: { title, body, userId: 1 } 
        });

        alert("Post created!");

        // Add new post card with Edit/Delete buttons
        const list = document.getElementById("posts-list");
        list.innerHTML = `
            <div class="col-md-6">
                <div class="card h-100 border-success">
                    <div class="card-body">
                        <h5 class="card-title">${newPost?.title ?? title}</h5>
                        <p class="card-text">${newPost?.body ?? body}</p>
                        <button class="btn btn-sm btn-warning me-2 edit-btn" data-id="${newPost?.id ?? 101}">Edit</button>
                        <button class="btn btn-sm btn-danger delete-btn" data-id="${newPost?.id ?? 101}">Delete</button>
                        <span class="badge bg-success">New</span>
                    </div>
                </div>
            </div>
        ` + list.innerHTML;
    }
    resetForm();
});

// Edit/Delete event delegation
document.getElementById("posts-list").addEventListener("click", async (e) => {
    if (e.target.classList.contains("edit-btn")) {
        const id = e.target.dataset.id;
        const post = await apiFetch(`/posts/${id}`);
        document.getElementById("form-title").textContent = `Edit Post #${id}`;
        document.getElementById("save-btn").textContent = "Update";
        document.getElementById("post-id").value = id;
        document.getElementById("title").value = post?.title ?? "";
        document.getElementById("body").value = post?.body ?? "";
    }

    if (e.target.classList.contains("delete-btn")) {
        const id = e.target.dataset.id;
        if (confirm("Are you sure you want to delete this post?")) {
            await apiFetch(`/posts/${id}`, { method: "DELETE" });
            e.target.closest(".col-md-6").remove();
            alert("Post deleted!");
        }
    }
});

// Cancel button resets form
document.getElementById("cancel-btn").addEventListener("click", resetForm);

function resetForm() {
    document.getElementById("form-title").textContent = "Create Post";
    document.getElementById("save-btn").textContent = "Save";
    document.getElementById("post-id").value = "";
    document.getElementById("title").value = "";
    document.getElementById("body").value = "";
}

// Pagination
function renderPagination() {
    const paginationContainer = document.querySelector(".pagination-container");
    paginationContainer.innerHTML = "";

    let startPage = Math.max(1, currentPage - Math.floor(visiblePages / 2));
    let endPage = startPage + visiblePages - 1;

    if (endPage > totalPages) {
        endPage = totalPages;
        startPage = Math.max(1, endPage - visiblePages + 1);
    }

    // Previous button
    const prevBtn = document.createElement("button");
    prevBtn.textContent = "Previous";
    prevBtn.className = "btn btn-outline-primary me-2";
    prevBtn.disabled = currentPage === 1;
    prevBtn.addEventListener("click", () => {
        if (currentPage > 1) {
            currentPage--;
            getPosts(currentPage);
        }
    });
    paginationContainer.appendChild(prevBtn);

    // Page numbers
    for (let i = startPage; i <= endPage; i++) {
        const pageBtn = document.createElement("button");
        pageBtn.textContent = i;
        pageBtn.className = `btn ${i === currentPage ? "btn-primary" : "btn-outline-primary"} me-1`;
        pageBtn.addEventListener("click", () => {
            currentPage = i;
            getPosts(currentPage);
        });
        paginationContainer.appendChild(pageBtn);
    }

    // Next button
    const nextBtn = document.createElement("button");
    nextBtn.textContent = "Next";
    nextBtn.className = "btn btn-outline-primary ms-2";
    nextBtn.disabled = currentPage === totalPages;
    nextBtn.addEventListener("click", () => {
        if (currentPage < totalPages) {
            currentPage++;
            getPosts(currentPage);
        }
    });
    paginationContainer.appendChild(nextBtn);
}

// Refresh
document.getElementById("refresh-btn").addEventListener("click", () => {
    getPosts(currentPage);
});

// Initial load
getPosts(currentPage);
