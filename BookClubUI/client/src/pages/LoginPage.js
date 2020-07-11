import React, {useState, useContext} from 'react';
import { AuthContext } from '../context/AuthContext';
import { useHttp } from '../postForms/loginPostForm';
import {useHistory} from 'react-router-dom'

function LoginPage (props) {
  const {loading, error, request} = useHttp()
  const [loginState, setLoginState] = useState({login: ''})
  const [errorState, setErrorState] = useState({errorText: ''})
  const history = useHistory();
  const auth = useContext(AuthContext)
  if (auth.isAuthenticated){
    history.push("/cabinet");
  }
  const changeHandler = event => {
    setLoginState({...loginState, [event.target.name]: event.target.value})
  }
  const submitLoginHandler = async (event) => {
    event.preventDefault();
    try {
      const data = await request(
        '/api/bookclub/login',
        'POST', {...loginState})
      auth.login = data.login
      auth.id = data.id
      auth.isAuthenticated = true

      history.push("/cabinet");
    } catch (error) {
      auth.login = null
      auth.id = null
      auth.isAuthenticated = false

      setErrorState({errorText: error.message})
    }
  }

    return (
      <div className="AuthPage">
        <form>
          <div>
            <div>
              <label htmlFor="login">Login</label>
              <input type="text" 
              id="login" 
              name="login"
              onChange={changeHandler}/>
            </div>

            <div>
              <span>{errorState.errorText}</span>
            </div>

            <div>
                <button type="submit" 
                onClick = {submitLoginHandler} 
                disabled = {loading}
                >Войти в систему</button>
            </div>
          </div>
          
        </form>
      </div>
  )
}

export default LoginPage