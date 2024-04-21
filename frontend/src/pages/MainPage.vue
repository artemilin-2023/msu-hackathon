<script setup lang="ts">
import landingImage from '../assets/landing.png';
import landingImageBad from '../assets/landingCompressed.jpg';
import { userdataUserApi } from '../api';
import { onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';
import { mdiHeart, mdiDuck, mdiMagnify } from '@mdi/js';

const { currentRoute, push } = useRouter();
import { useProfileStore } from '../store';

const profileStore = useProfileStore();

const showUserWarn = ref(false);
const searchText = ref(currentRoute.value?.query['q'] ?? '');

onMounted(async () => {
	// Get username
	if (!profileStore.full_name && profileStore.id) {
		const resp = await userdataUserApi.getById(profileStore.id);
		if (resp.status != 200) {
			showUserWarn.value = true;
			return;
		}
		const data = resp.data;
		if (!data || !data.items) {
			showUserWarn.value = true;
			return;
		}
		const nameItem = data.items.find(item => {
			return item.category == 'Личная информация' && item.param == 'Полное имя';
		});
		if (!nameItem) {
			showUserWarn.value = true;
			return;
		}
		profileStore.full_name = nameItem?.value ?? null;
	}
});
</script>

<template>
	<div style="position: relative; z-index: 1; min-height: 100vh">
		<v-img :lazy-src="landingImageBad" :src="landingImage" cover height="100vh" class="tinted">
			<v-sheet
				color="rgba(0 0 0 / 0)"
				class="d-flex flex-column pa-16 text-center overlay text-white header"
				height="100vh"
			>
				<span class="text-h3 text-md-h2 text-lg-h1 pt-16">Матроссинг</span>
				<span class="text-h7 text-md-h6 text-lg-h5 pt-5">Студенческая программа для обмена материалами</span>
				<div class="flex pt-8">
					<v-text-field
						v-model="searchText"
						hide-details="auto"
						label="Найди что-нибудь!"
						variant="solo"
						density="compact"
						:append-inner-icon="mdiMagnify"
						@update:focused="
							push({
								path: '/search',
								query: currentRoute.query,
							})
						"
					/>
				</div>
				<div v-if="showUserWarn" class="flex pt-8">
					<v-btn
						block
						label="З"
						@click="
							push({
								path: '/upload',
								query: currentRoute.query,
							})
						"
						>Загрузи что-нибудь своё!</v-btn
					>
				</div>
				<div v-if="showUserWarn" class="flex pt-8">
					<v-btn
						block
						label="З"
						@click="
							push({
								path: '/my_works',
								query: currentRoute.query,
							})
						"
						>Посмотри свои загрузки!</v-btn
					>
				</div>
				<div v-if="!showUserWarn" class="flex pt-8">
					<v-alert
						title="Не авторизован!"
						text="Для загрузки и изменения работ необходимо войти на сайт через приложение ТвойФФ. Нажмите кнопку ниже, что бы попасть в него"
						type="warning"
					></v-alert>
				</div>
				<div v-if="!showUserWarn" class="flex pt-8">
					<v-btn
						block
						color="orange"
						label="З"
						@click="
							push({
								path: 'https://app.test.profcomff.com/auth',
							})
						"
						>Авторизоваться</v-btn
					>
				</div>
				<div class="mt-auto">
					<v-btn
						variant="plain"
						@click="
							push({
								path: '/about',
								query: currentRoute.query,
							})
						"
						><span style="color: white">О сайте</span></v-btn
					>
				</div>
			</v-sheet>
		</v-img>
	</div>

	<v-footer style="position: sticky; bottom: 0" class="justify-center" color="rgb(0,1,76)">
		Made with
		<v-icon :icon="mdiHeart" color="red" start end />
		by
		<v-icon :icon="mdiDuck" color="yellow" end />
	</v-footer>
</template>

<style scoped>
.header {
	font-family: 'IBM Plex Sans', Roboto, sans-serif;
}

.overlay {
	z-index: 1;
	position: relative;
}

.tinted::before {
	content: '';
	display: block;
	position: absolute;
	inset: 0;
	background-color: rgba(0 0 0 / 66%);
}
</style>
