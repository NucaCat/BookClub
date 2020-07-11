import {useState, useCallback} from 'react'

export const useHttp = () => {
    const [loading, setLoading] = useState(false)
    const [error, setError] = useState(null)

    const request = useCallback(async (url, method = 'GET', body = null, headers = {}) => {
        setLoading(true)
        try {
            headers['Content-Type'] = 'application/json'
            const responce = await fetch(url, {method, body: JSON.stringify(body), headers})
            const data = await responce.json()
            if (!responce.ok){
                throw new Error(data.message || 'Вход не удался')
            }
            setLoading(false)
            return data
        } catch (e) {
            setError(e.message)
            setLoading(false)
            throw e
        }
    }, [])

    const clearError = () => setError(null)

    return {loading, request, error}
}

