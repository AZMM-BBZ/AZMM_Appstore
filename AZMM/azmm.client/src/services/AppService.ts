import axios, { AxiosResponse } from 'axios';
import { saveAs } from 'file-saver';

class AppService {

    private baseUrl: string = "http://localhost:5096";
    private token: string | null;

    constructor() {
        this.token = null;
    }

    private setAuthToken(token: string) {
        this.token = token;
        axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    }

    private clearAuthToken() {
        this.token = null;
        delete axios.defaults.headers.common['Authorization'];
    }

    private get<T>(url: string, params?: any): Promise<AxiosResponse<T>> {
        return axios.get<T>(`${this.baseUrl}${url}`, { params });
    }

    private post<T>(url: string, data?: any): Promise<AxiosResponse<T>> {
        return axios.post<T>(`${this.baseUrl}${url}`, data);
    }

    authenticateUser(name: string, password: string): Promise<boolean> {
        let authenticationRequestBody: AuthenticationRequestBody = {
            username: name,
            password: password
        }
        return this.post<string>('/Authentication/authenticate', authenticationRequestBody)
            .then(response => {
                this.setAuthToken(response.data);
                return true;
            }).catch(error => {
                return false;
            });
    }

    getCurrentUser(): Promise<any> {
        return this.get<UserDto>('/User/getCurrentUser')
            .then(response => {
                return response;
            })
            .catch(error => {
                return null
            });
    }

    addUser(userDto: UserDto): Promise<boolean> {
        return this.post<void>('/Authentication/addUser', userDto)
        .then(response => {
            return true;
        }).catch(error => {
            return false;
        });;
    }

    updateUser(userDto: UserDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/User/updateUser', userDto);
    }

    deleteUser(userDto: UserDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/User/deleteUser', userDto);
    }

    //downloadApp(appId: number): Promise<AxiosResponse<Blob>> {
    //    return this.get<Blob>('/App/downloadApp', { appId });
    //}

    async downloadApp(appId: number) {
        try {
            const response = await axios.get('http://localhost:5096/App/downloadApp', {
                params: { aid: appId }, // Set the appropriate `aid` parameter
                responseType: 'blob' // Important for handling binary data
            });

            // Create a Blob from the response data
            const blob = new Blob([response.data], { type: 'application/zip' });

            // Use FileSaver.js to save the file
            saveAs(blob, 'Executable.zip');
        } catch (error) {
            console.error('Error downloading the app:', error);
        }
    }

    getAppWithCategory(category: Category): Promise<AxiosResponse<AppDto[]>> {

        return this.get<AppDto[]>('/App/getAppWithCategory', { category });
    }

    getAppsOfUser(): Promise<AxiosResponse<AppDto[]>> {
        return this.get<AppDto[]>('/App/getAppsOfUser');
    }

    purchaseApp(appDto: AppDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/App/purchaseApp', appDto);
    }

    uploadApp(appDto: AppDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/App/uploadApp', appDto);
    }

    deleteApp(appDto: AppDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/App/deleteApp', appDto);
    }

    updateApp(appDto: AppDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/App/updateApp', appDto);
    }
}

// DTO interfaces (Define them based on your backend API)
interface UserDto {
    uid: number,
    name: string,
    password: string,
    owenedApps: [AppDto],
}

interface AppDto {
    aid: number,
    name: string,
    description: string,
    title: string,
    imageUrl: string,
    price: number,
    category: Category,
}

interface AuthenticationRequestBody {
    username: string,
    password: string
}

enum Category {
    None = 0,
    Game = 1,
    Learning = 2,
    Activity = 3,
    SocialMedia = 4,
    Work = 5,
}

export default AppService;
