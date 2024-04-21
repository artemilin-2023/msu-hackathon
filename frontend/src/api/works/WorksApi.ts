import { BaseApi } from '../BaseApi';

export interface WorkResponse {
	id: string;
	count?: string;
}

export interface WorksSearchParams {
	course: number | null;
	subject: string | null;
	worktype: string | null;
	limit: number | null;
	query: string;
}

class TouchMeApi extends BaseApi {
	constructor() {
		super('', import.meta.env.VITE_API_BASE_URL ?? document.location.origin);
	}
	public async getWorks(req: WorksSearchParams) {
		const url = new URL(this.url);
		if (req.course) url.searchParams.set('course', `${req.course}`);
		if (req.subject) url.searchParams.set('subject', req.subject);
		if (req.worktype) url.searchParams.set('worktype', req.worktype);
		url.searchParams.set('name', req.query);
		return this.get<WorkResponse[]>(`/works${url.search}`);
	}
	public async getWork(guid: string) {
		return this.post<WorkResponse>(`/works/{$guid}`);
	}
}

export const touchMeApi = new TouchMeApi();
