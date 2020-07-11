import {useState} from 'react'

export const useAuth = () => {
    const [login, setLogin] = useState(null)
    const [id, setId] = useState(null)
    const [isAuthenticated, setIsAuthenticated] = useState(null)

    return {login, id, isAuthenticated}
}