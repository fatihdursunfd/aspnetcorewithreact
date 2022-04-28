import React, { useState } from "react";
import Constants from "./Utilities/Constants";
import PostCreateForm from "./Components/PostCreateForm";
import PostUpdateForm from "./Components/PostUpdateForm";

export default function App() {

  const [posts, setPosts] = useState([]);
  const [showingCreateNewForm, setshowingCreateNewForm] = useState(false);
  const [postCurrentlyBeingUpdated, setpostCurrentlyBeingUpdated] = useState(null);

  function getPosts() {
    const url = Constants.API_URL_GET_ALL_POSTS;

    fetch(url, { method: 'GET' })
        .then(response => response.json())
        .then(posts => { setPosts(posts); })
        .catch((err) => { alert(err) } 
      );
  }

  function deletePost(postID) {

    const url = `${Constants.API_URL_GET_POST_BY_ID}/${postID}`;

    fetch(url, { method: 'GET' })
        .then(response => response.json())
        .then(responseFromServer => { 
                if( responseFromServer !== null){
                    const urlDelete = `${Constants.API_URL_DELETE_POST}/${postID}`;
                    fetch(urlDelete , {method : "DELETE"})
                      .then(r => r.json())
                      .catch((err2) => {alert(err2)})
                      onPostDeleted(postID)
                }})
        .catch((err) => { alert(err) } 
      );
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {
            (showingCreateNewForm === false &&  postCurrentlyBeingUpdated === null ) && (

              <div>
                <h1>ASP NET CORE WİTH REACT</h1>
                <div className="mt-5">
                  <button className="btn btn-dark btn-lg w-100" onClick={getPosts}>Get Posts From The Server</button>
                  <button className="btn btn-secondary btn-lg w-100 mt-4" onClick={() => setshowingCreateNewForm(true)}>Create a New Post</button>
                </div>
              </div>

            )}


          {(posts.length > 0 && showingCreateNewForm === false && postCurrentlyBeingUpdated === null ) && renderPostTable()}

          {showingCreateNewForm && <PostCreateForm onPostCreated={onPostCreated} />}

          {postCurrentlyBeingUpdated !== null && <PostUpdateForm post={postCurrentlyBeingUpdated} onPostUpdated={onPostUpdated} />}

        </div>
      </div>
    </div>
  );

  function renderPostTable() {
    return (

      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col"> Post ID</th>
              <th scope="col"> Post Title</th>
              <th scope="col"> Post Content</th>
              <th scope="col"> CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {posts.map((post) => (
              <tr key={post.postID}>
                <th scope="row"> {post.postID} </th>
                <td> {post.title}</td>
                <td> {post.content}</td>
                <td>
                  <button onClick={() => setpostCurrentlyBeingUpdated(post)} className="btn btn-dark btn-lg mx-3 my-3"> Update </button>
                  <button onClick={() => { if(window.confirm(`Are you sure want to delete post ${post.title}`)) deletePost(post.postID) }} className="btn btn-secondary btn-lg mx-3 my-3"> Delete </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => setPosts([])} className="btn btn-dark btn-lg w-100" > Empty posts array  </button>

      </div>


    )
  }

  function onPostCreated(post) {

    setshowingCreateNewForm(false);

    if (post === null) {
      return
    }

    alert("Post succesfully created")

    getPosts();

  }

  function onPostUpdated(post) {

      setpostCurrentlyBeingUpdated(null)

      if(post === null) {
          return ; 
      }

      let postsCopy = [...posts];

      const index = postsCopy.findIndex((postCopyPost , currentIndex) => {
          if(postCopyPost.postID === post.postId) {
            return true ;
          }
      });

      if(index !== -1 ) {
        postsCopy[index]  = post;
      }

      setPosts(postsCopy)
      alert("post succesfully updated");

  }

  function onPostDeleted(postID) {

      let postsCopy = [...posts];

      const index = postsCopy.findIndex((postCopyPost , currentIndex) => {
          if(postCopyPost.postID === postID) {
            return true ;
          }
      });

      if(index !== -1 ) {
        postsCopy.splice(index,1);
      }

      setPosts(postsCopy)
      alert("post succesfully deleted");
  }

}

