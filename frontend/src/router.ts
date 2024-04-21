import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router';
import MainPage from './pages/MainPage.vue';
import SearchPage from './pages/SearchPage.vue';
import UploadPage from './pages/UploadPage.vue';
import MyWorksPage from './pages/MyWorksPage.vue';

const routes: RouteRecordRaw[] = [
	{
		path: '/',
		component: MainPage,
	},
	{
		path: '/search',
		component: SearchPage,
	},
	{
		path: '/upload',
		component: UploadPage,
	},
	{
		path: '/my_works',
		component: MyWorksPage,
	},
];

export default createRouter({
	history: createWebHistory(import.meta.env.BASE_URL),
	routes,
});
