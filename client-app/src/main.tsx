import ReactDOM from 'react-dom/client';
import 'semantic-ui-css/semantic.min.css';
import 'react-calendar/dist/Calendar.css';
import 'react-toastify/dist/ReactToastify.css';
import 'react-datepicker/dist/react-datepicker.css';
import './app/layout/styles.css';
import { store, StoreContext } from './app/stores/stores';
import { RouterProvider, } from 'react-router-dom';
import { router } from './app/router/routes';



ReactDOM.createRoot(document.getElementById('root')!).render(

    <StoreContext.Provider value={store}>
      <RouterProvider router={router} />
    </StoreContext.Provider> 
    
)
