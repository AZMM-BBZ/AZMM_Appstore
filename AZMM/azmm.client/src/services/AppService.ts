import axios, { AxiosResponse } from 'axios';

class AppService {
    private baseUrl: string;
    private token: string | null;

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
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

    authenticateUser(name: string, password: string): Promise<AxiosResponse<string>> {
        return this.post<string>('/Authentication/authenticate', { name, password })
            .then(response => {
                this.setAuthToken(response.data);
                return response;
            });
    }

    getCurrentUser(): Promise<AxiosResponse<UserDto>> {
        return this.get<UserDto>('/User/getCurrentUser');
    }

    addUser(userDto: UserDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/User/addUser', userDto);
    }

    updateUser(userDto: UserDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/User/updateUser', userDto);
    }

    deleteUser(userDto: UserDto): Promise<AxiosResponse<void>> {
        return this.post<void>('/User/deleteUser', userDto);
    }

    downloadApp(appId: string): Promise<AxiosResponse<Blob>> {
        return this.get<Blob>('/App/downloadApp', { appId });
    }

    getAppWithCategory(category: string): Promise<AxiosResponse<AppDto[]>> {
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
    email: string,
    owenedApps: [AppDto],
    moneySpent: number
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


enum Category {
    None = 0,
    Game = 1,
    Learning = 2,
    Activity = 3,
    SocialMedia = 4,
    Work = 5,
}

export default AppService;
