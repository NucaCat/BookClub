import {createContext} from 'react'

export const AuthContext = createContext({
    login: null,
    id: null,
    isAuthenticated: false
})