<script setup lang="ts">
import { onMounted } from 'vue';
import { useProfileStore } from './store';

const profileStore = useProfileStore();

onMounted(() => {
	profileStore.fromUrl();
});
</script>

<template>
	<v-app>
		<v-main>
			<RouterView />
		</v-main>
	</v-app>
</template>
