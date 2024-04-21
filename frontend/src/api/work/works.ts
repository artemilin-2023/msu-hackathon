import { BaseApi } from '../BaseApi';

export interface FiltersRequest {
    Course: number,
    Name: string,
    WorkTypw: string,
    Subject: string,
    Limit: number
}

export interface PostWorksRequest{
    Name: string,
    Hierarchy: {
        Course: number,
        Subject: string,
        WorkType: string
    },
    Files: FileList
}

export interface GetAllResponse{

}

class WorksAPI extends BaseApi {
	constructor() {
		super('', import.meta.env.VITE_API_BASE_URL ?? document.location.origin);
	}

	public async postWork() {
		return this.post("/api/v1/works")
	}

	public async getAll() {
		return this.post<>('/api/v1/works');
	}
}
