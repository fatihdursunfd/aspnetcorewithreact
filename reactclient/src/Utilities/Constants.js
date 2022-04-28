const API_BASE_URL_DEVELOPMENT = 'https://localhost:7237'
const API_BASE_URL_PRODUCTİON = 'https://aspnetcorewithreact.azurewebsites.net'

const ENDPOINTS = {
    GET_ALL_POSTS : "get-all-posts" ,
    GET_POST_BY_ID : "get-post-by-id",
    CREATE_POST : "create-post",
    UPDATE_POST : "update-post",
    DELETE_POST : "delete-post-by-id"
};

const development = {
    API_URL_GET_ALL_POSTS : `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_POSTS}` ,
    API_URL_GET_POST_BY_ID : `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_POST_BY_ID}` ,
    API_URL_CREATE_POST : `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.CREATE_POST}` ,
    API_URL_UPDATE_POST : `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.UPDATE_POST}` ,
    API_URL_DELETE_POST : `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.DELETE_POST}` 
}

const production = {
    API_URL_GET_ALL_POSTS : `${API_BASE_URL_PRODUCTİON}/${ENDPOINTS.GET_ALL_POSTS}` ,
    API_URL_GET_POST_BY_ID : `${API_BASE_URL_PRODUCTİON}/${ENDPOINTS.GET_POST_BY_ID}` ,
    API_URL_CREATE_POST : `${API_BASE_URL_PRODUCTİON}/${ENDPOINTS.CREATE_POST}` ,
    API_URL_UPDATE_POST : `${API_BASE_URL_PRODUCTİON}/${ENDPOINTS.UPDATE_POST}` ,
    API_URL_DELETE_POST : `${API_BASE_URL_PRODUCTİON}/${ENDPOINTS.DELETE_POST}` 
}

const Constants = process.env.NODE_ENV === 'development' ? development : production ;

export default Constants;
