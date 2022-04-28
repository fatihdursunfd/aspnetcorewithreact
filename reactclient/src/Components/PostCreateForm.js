import React, { useState } from 'react'
import Constants from '../Utilities/Constants'


export default function PostCreateForm(props) {

    const initialFormData = Object.freeze ({
        title: "POST X",
        content: "CONTENT X"
    });

    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        const post = {
            PostID: 0,
            Title: formData.title,
            Content: formData.content
        }

        const url = Constants.API_URL_CREATE_POST;

        fetch(url, {
            method: 'POST',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(post)
        })
            .then(response => response.json())
            .then(responseFromServer => { console.log(responseFromServer); })
            .catch((err) => { alert(err) });


        props.onPostCreated(post)

    }

    return (
            <form className='w-100 px-5'>
                <h1 className='mt-5'> Create a New Post </h1>

                <div className='mt-5'>
                    <label className='h3 form-label'> Post Title </label>
                    <input value={formData.title} name="title" type="text" onChange={handleChange} className="form-control" />
                </div>

                <div className='mt-5'>
                    <label className='h3 form-label'> Post content </label>
                    <input value={formData.content} name="content" type="text" onChange={handleChange} className="form-control" />
                </div>

                <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5"> Submit </button>
                <button onClick={() => props.onPostCreated(null)} className="btn btn-secondary btn-lg w-100 mt-5"> Cancel </button>

            </form>
    )
}
