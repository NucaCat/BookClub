import React, {useState, useContext, useEffect} from 'react';
import { AuthContext } from '../context/AuthContext';
import {useHistory} from 'react-router-dom'
import BookComponent from './components/BookComponent'

function CabinetPage (props) {
  const auth = useContext(AuthContext)
  const [readerState, setReaderState] = useState({
      reader: {
        id: auth.id,
        login: auth.login,
        books: []
      },
      allBooks: [], 
      isFetching: true
  })
  const [myBooks, setMyBooks] = useState(false)
  const [errorState, setErrorState] = useState({errorText: ''})
  const [dummyState, setDummyState] = useState(false)
  
  const history = useHistory()
  if (!auth.isAuthenticated){
    history.push("/login");
  }

  useEffect(() => {
    let cleanupFunction = false;
    const foo = async () => {
      try {
        let headers = {}
        let responce = await fetch('/api/bookclub/books', { 
          method: 'GET',
          headers
        })
        const data1 = await responce.json()
        if (!responce.ok){
            throw new Error(data1.message || 'Не удалось загрузить список книг')
        }
        headers = {}
        responce = await fetch(`/api/bookclub/readersWithBooks/${auth.id}`, { 
          method: 'GET',
          headers
        })
        const data2 = await responce.json()
        data2.id = auth.id
        if(!cleanupFunction) setReaderState({reader: data2, allBooks: data1, isFetching: false})
        if (!responce.ok){
            throw new Error(data2.message || 'Не удалось загрузить список книг пользователя')
        }
      } catch (error) {
        if(!cleanupFunction) setErrorState({errorText: error.message})
      }
    }
    foo()
    return () => cleanupFunction = true;
  }, [auth]);

  const saveChangesHandler = async (event) => {
    event.preventDefault()
    try{
      let headers = {}
      headers['Content-Type'] = 'application/json'
      let responce = await fetch(`/api/bookclub/readers`, { 
        method: 'PUT',
        body: JSON.stringify(readerState.reader),
        headers
      })
      const data = await responce.json()
    } catch(error) {
      console.log(error.message)
    }
  }
  
  const readChangeHandler = (book) => {
    setReaderState(state => {
      let books = []
      if (book.ToAdd)
      {
        books = state.reader.books.concat({id: book.id, bookName: book.bookName});
      } else {
        books = state.reader.books.filter(item => item.id !== book.id);
      }
      books = books.sort().filter((item, pos, ary) => !pos || (item.id != ary[pos - 1].id))
      let reader = readerState
      reader.reader.books = books
      return reader;
    });
    setDummyState(!dummyState)
  }
  
  return (
    <div className="CabinetPage">
    <form>
        <div>
            <span>{auth.login}</span>
        </div>
        <div>
          Только прочитанные книги
          <input type='checkbox' value={false} onChange={() => setMyBooks(!myBooks)} />
        </div>
        <div>
            <span>{errorState.errorText}</span>
        </div>
        <div>
            {readerState.isFetching 
                ? <p>fetching...</p> 
                : myBooks 
                  ? readerState
                  .reader
                  .books
                  .map(item => 
                      <BookComponent 
                      key = {item.id} 
                      id = {item.id} 
                      bookName = {item.bookName} 
                      alreadyRead = {readerState.reader.books.find(x => x.id === item.id) !== undefined}
                      readChangeHandler = {readChangeHandler}/>)
                  : readerState
                    .allBooks
                    .map(item => 
                      <BookComponent 
                      key = {item.id} 
                      id = {item.id} 
                      bookName = {item.bookName} 
                      alreadyRead = {readerState.reader.books.find(x => x.id === item.id) !== undefined}
                      readChangeHandler = {readChangeHandler}/>)}
        </div>
        
        <div>
            <button type="submit" 
            onClick = {saveChangesHandler}
            >Сохранить изменения</button>
        </div>
        
    </form>
    </div>
  )
}

export default CabinetPage