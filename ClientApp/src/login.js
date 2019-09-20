export const isLogin=()=>{
    let getToken = localStorage.getItem('token');
    if(getToken!=null) {
        return true
    }
    return false;
}
