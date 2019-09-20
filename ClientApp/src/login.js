import jwtDecode from 'jwt-decode';
export const isLogin=()=>{
    let token = localStorage.getItem('token');
    if(token!=null) {
        try {
          let decode = jwtDecode(token)
          console.log(decode)
        }
        catch(error) {
            console.log(error)
            return false;
        }
        return true
    }
    return false
}
